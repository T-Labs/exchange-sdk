using System;
using System.Net;
using System.Security.Principal;
using Audit.Core;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace TLabs.ExchangeSdk.Audit;

public static class AuditScopeExtensions
{
    public static AuditScope WithUserID(this AuditScope scope, [CanBeNull] string userID)
    {
        if (scope is null || userID is null)
            return scope;
        if (scope.Event is ExchangeAuditEvent auditEvent)
        {
            auditEvent.UserId = userID;
            return scope;
        }

        scope.SetCustomField(nameof(userID), userID, true);
        return scope;
    }

    public static AuditScope WithUserIP(this AuditScope scope, [CanBeNull] string userIP)
    {
        if (scope is null || userIP is null)
            return scope;
        if (scope.Event is ExchangeAuditEvent auditEvent)
        {
            auditEvent.IP = userIP;
            return scope;
        }

        scope.SetCustomField(nameof(userIP), userIP, true);
        return scope;
    }

    public static AuditScope WithUserAgent(this AuditScope scope, [CanBeNull] string userAgent)
    {
        if (scope is null || userAgent is null)
            return scope;
        if (scope.Event is ExchangeAuditEvent auditEvent)
        {
            auditEvent.UserAgent = userAgent;
            return scope;
        }

        scope.SetCustomField(nameof(userAgent), userAgent, true);
        return scope;
    }

    public static AuditScope WithUserID(this AuditScope scope, [CanBeNull] IIdentity user) =>
        scope.WithUserID(user?.Name);

    [CLSCompliant(false)]
    public static AuditScope WithHttpContext(this AuditScope scope, [CanBeNull] HttpContext ctx)
    {
        if (scope is null || ctx is null)
            return scope;

        var remoteIp = GetRemoteIp(ctx);
        var userAgent = GetUserAgent(ctx);
        if (scope.Event is ExchangeAuditEvent auditEvent)
        {
            auditEvent.IP = remoteIp;
            auditEvent.UserAgent = userAgent;
            auditEvent.UserId = ctx.User?.Identity?.Name;
            return scope;
        }

        return scope
            .WithUserID(ctx.User?.Identity?.Name)
            .WithUserIP(remoteIp)
            .WithUserAgent(userAgent);
    }

    public static AuditScope DiscardIf(this AuditScope scope, bool discard)
    {
        if (discard)
            scope?.Discard();

        return scope;
    }

    public static string GetRemoteIp([CanBeNull] HttpContext ctx)
    {
        if (ctx is null)
            return null;

        var ip = ctx.Connection.RemoteIpAddress;
        if (ip is not null)
        {
            if (ip.IsIPv4MappedToIPv6)
                ip = ip.MapToIPv4();
            return ip.ToString();
        }

        return FirstForwardedIp(ctx.Request.Headers, "X-Forwarded-For")
            ?? FirstForwardedIp(ctx.Request.Headers, "X-Real-IP");
    }

    public static string GetUserAgent([CanBeNull] HttpContext ctx)
    {
        if (ctx is null)
            return null;

        var agent = ctx.Request.Headers["User-Agent"].ToString();
        return string.IsNullOrWhiteSpace(agent) ? null : agent;
    }

    private static string FirstForwardedIp(IHeaderDictionary headers, string headerName)
    {
        if (!headers.TryGetValue(headerName, out var value))
            return null;

        var raw = value.ToString();
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        var first = raw.Split(',')[0].Trim();
        return string.IsNullOrWhiteSpace(first) ? null : first;
    }
}
