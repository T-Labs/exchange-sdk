using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Audit.Core;
using Microsoft.AspNetCore.Http;

namespace TLabs.ExchangeSdk.Audit;

public class AuditScopeLight
{
    private static readonly Regex LocalFunctionRegex = new(@"\<(?<Owner>.{0,})\>g__(?<function>.{0,})\|.*", RegexOptions.Compiled);
    private static readonly Regex AsyncStateMachineRegex = new(@"<(?<method>.+)>d__\d+", RegexOptions.Compiled);

    public static bool IsAuditActive { get; set; } = true;

    public static AuditScope Track(
        HttpContext ctx,
        Func<object> selector = null,
        int trackDepth = 1,
        AuditDataProvider provider = null,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "") =>
        CreateScope(ctx, selector, eventType: null, trackDepth, provider, callerName, callerFilePath);

    public static AuditScope Track(
        HttpContext ctx,
        string eventType,
        Func<object> selector = null,
        AuditDataProvider provider = null,
        [CallerMemberName] string callerName = "",
        [CallerFilePath] string callerFilePath = "") =>
        CreateScope(ctx, selector, eventType, trackDepth: 1, provider, callerName, callerFilePath);

    private static AuditScope CreateScope(
        HttpContext ctx,
        Func<object> selector,
        string eventType,
        int trackDepth,
        AuditDataProvider provider,
        string callerName,
        string callerFilePath)
    {
        if (!IsAuditActive)
            return null;

        var resolvedType = string.IsNullOrWhiteSpace(eventType)
        var resolvedType = !string.IsNullOrWhiteSpace(eventType)
            ? eventType
            : trackDepth == 1
                ? ResolveEventType(callerName, callerFilePath, trackDepth)
                : ResolveEventType(callerName: null, callerFilePath: null, trackDepth);
            : eventType;
        var scope = AuditScope.Create(new AuditScopeOptions
        {
            EventType = resolvedType,
            TargetGetter = selector,
            CreationPolicy = EventCreationPolicy.InsertOnEnd,
            AuditEvent = new ExchangeAuditEvent(),
            DataProvider = provider,
        }).WithHttpContext(ctx);

        return scope;
    }

    internal static string ResolveEventType(string callerName, string callerFilePath, int trackDepth = 1)
    {
        if (!string.IsNullOrWhiteSpace(callerName) && !string.IsNullOrWhiteSpace(callerFilePath))
        {
            var className = Path.GetFileNameWithoutExtension(callerFilePath);
            if (!string.IsNullOrWhiteSpace(className))
                return MakeEventType(callerName, className);
        }

        var stack = new StackTrace();
        var frame = WalkFrames(stack, trackDepth);
        var (methodName, classType) = Deconstruct(frame);
        return MakeEventType(methodName, classType);
    }

    internal static StackFrame WalkFrames(StackTrace stackTrace, int depth = 1)
    {
        if (depth >= stackTrace.FrameCount)
            throw new InvalidOperationException();

        var frame = stackTrace.GetFrame(depth);
        var method = frame.GetMethod();
        var declaringType = method.DeclaringType;
        if (declaringType is null)
            return WalkFrames(stackTrace, ++depth);
        if (IsSkippedInfrastructure(declaringType))
            return WalkFrames(stackTrace, ++depth);
        if (string.Equals(method.Name, "MoveNext", StringComparison.OrdinalIgnoreCase)
            && TryUnwrapAsyncStateMachine(declaringType) is null)
            return WalkFrames(stackTrace, ++depth);

        return frame;
    }

    private static bool IsSkippedInfrastructure(Type declaringType)
    {
        var typeName = declaringType.Name;
        var ns = declaringType.Namespace ?? string.Empty;
        return typeName.Equals("AsyncMethodBuilderCore", StringComparison.OrdinalIgnoreCase)
            || typeName.StartsWith("AsyncTaskMethodBuilder", StringComparison.Ordinal)
            || typeName.StartsWith("AsyncValueTaskMethodBuilder", StringComparison.Ordinal)
            || typeName.StartsWith("AsyncStateMachineBox", StringComparison.Ordinal)
            || typeName.Contains("IActionResultExecutor", StringComparison.Ordinal)
            || typeName.Contains("ActionMethodExecutor", StringComparison.Ordinal)
            || typeName.Contains("ControllerActionInvoker", StringComparison.Ordinal)
            || ns.StartsWith("Microsoft.AspNetCore.Mvc", StringComparison.Ordinal);
    }

    internal static (string methodName, Type clazz) Deconstruct(StackFrame frame)
    {
        var method = frame.GetMethod();
        var declaringType = method.DeclaringType;

        if (string.Equals(method.Name, "MoveNext", StringComparison.OrdinalIgnoreCase)
            && TryUnwrapAsyncStateMachine(declaringType) is { } unwrapped)
            return unwrapped;

        if (LocalFunctionRegex.IsMatch(method.Name))
            return (LocalFunctionRegex.Match(method.Name).Groups["function"].Value, declaringType);

        return (method.Name, declaringType);
    }

    private static (string methodName, Type clazz)? TryUnwrapAsyncStateMachine(Type declaringType)
    {
        if (declaringType is null)
            return null;

        var match = AsyncStateMachineRegex.Match(declaringType.Name);
        if (!match.Success)
            return null;

        return (match.Groups["method"].Value, declaringType.DeclaringType ?? declaringType);
    }

    internal static string MakeEventType(string methodName, MemberInfo classType) =>
        MakeEventType(methodName, classType?.Name);

    internal static string MakeEventType(string methodName, string className)
    {
        Expression<Func<char, IEnumerable<char>>> processor =
            x => !char.IsUpper(x) ? $"{x}" : $":{x}".ToLowerInvariant();
        var exp = processor.Compile();

        className ??= "unknown";
        methodName ??= "unknown";
        if (!className.Any(char.IsLower))
            className = className.ToLowerInvariant();
        if (!methodName.Any(char.IsLower))
            methodName = methodName.ToLowerInvariant();

        var normalizedClassName = NormalizeName(className.Replace("Controller", ""), exp);
        var normalizedMethodName = NormalizeName(methodName, exp)
            .Replace(":async", "");

        return $"{normalizedClassName}:{normalizedMethodName}";
    }

    private static string NormalizeName(string name, Func<char, IEnumerable<char>> exp)
    {
        var normalized = string.Join("", name.SelectMany(exp));
        if (normalized.Length > 0 && normalized[0] == ':')
            normalized = normalized.Remove(0, 1);
        return normalized;
    }
}
