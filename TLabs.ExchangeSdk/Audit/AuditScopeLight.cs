using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Audit.Core;
using Microsoft.AspNetCore.Http;

namespace TLabs.ExchangeSdk.Audit;

public class AuditScopeLight
{
    public static bool IsAuditActive { get; set; } = true;

    public static AuditScope Track(
        HttpContext ctx,
        Func<object> selector = null,
        int trackDepth = 1,
        AuditDataProvider provider = null)
    {
        if (!IsAuditActive)
            return null;

        var stack = new StackTrace();
        var frame = WalkFrames(stack, trackDepth);
        var (methodName, classType) = Deconstruct(frame);

        var eventType = MakeEventType(methodName, classType);
        var scope = AuditScope.Create(new AuditScopeOptions
        {
            EventType = eventType,
            TargetGetter = selector,
            CreationPolicy = EventCreationPolicy.InsertOnEnd,
            AuditEvent = new ExchangeAuditEvent(),
            DataProvider = provider,
        }).WithHttpContext(ctx);

        return scope;
    }

    internal static StackFrame WalkFrames(StackTrace stackTrace, int depth = 1)
    {
        if (depth >= stackTrace.FrameCount)
            throw new InvalidOperationException();

        var frame = stackTrace.GetFrame(depth);
        var method = frame.GetMethod();
        if (string.Equals(method.Name, "MoveNext", StringComparison.InvariantCultureIgnoreCase))
            return WalkFrames(stackTrace, ++depth);
        if (method.DeclaringType is null)
            return WalkFrames(stackTrace, ++depth);
        if (IsAsyncInfrastructure(method.DeclaringType))
            return WalkFrames(stackTrace, ++depth);

        return frame;
    }

    private static bool IsAsyncInfrastructure(Type declaringType)
    {
        var typeName = declaringType.Name;
        return typeName.Equals("AsyncMethodBuilderCore", StringComparison.OrdinalIgnoreCase)
            || typeName.StartsWith("AsyncTaskMethodBuilder", StringComparison.Ordinal)
            || typeName.StartsWith("AsyncValueTaskMethodBuilder", StringComparison.Ordinal);
    }

    internal static (string methodName, Type clazz) Deconstruct(StackFrame frame)
    {
        var method = frame.GetMethod();
        var localFunctionRegex = new Regex(@"\<(?<Owner>.{0,})\>g__(?<function>.{0,})\|.*", RegexOptions.Compiled);

        if (localFunctionRegex.IsMatch(method.Name))
            return (localFunctionRegex.Match(method.Name).Groups["function"].Value, method.DeclaringType);

        return (method.Name, method.DeclaringType);
    }

    internal static string MakeEventType(string methodName, MemberInfo classType)
    {
        Expression<Func<char, IEnumerable<char>>> processor =
            x => !char.IsUpper(x) ? $"{x}" : $":{x}".ToLowerInvariant();
        var exp = processor.Compile();

        var className = classType.Name;
        if (!className.Any(char.IsLower))
            className = className.ToLowerInvariant();
        if (!methodName.Any(char.IsLower))
            methodName = methodName.ToLowerInvariant();

        var normalizedClassName = string.Join("", className
            .Replace("Controller", "")
            .SelectMany(exp))
            .Remove(0, 1);
        var normalizedMethodName = string.Join("", methodName
            .SelectMany(exp))
            .ToLowerInvariant()
            .Replace(":async", "")
            .Remove(0, 1);

        return $"{normalizedClassName}:{normalizedMethodName}";
    }
}
