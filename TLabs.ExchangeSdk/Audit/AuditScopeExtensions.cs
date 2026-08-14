using System;
using System.Security.Principal;
using Audit.Core;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace TLabs.ExchangeSdk.Audit;

public static class AuditScopeExtensions
{
    public static AuditScope WithUserID(this AuditScope scope, [CanBeNull] string userID)
    {
        if (userID is null)
            return scope;
        scope.SetCustomField(nameof(userID), userID, true);
        return scope;
    }

    public static AuditScope WithUserIP(this AuditScope scope, [CanBeNull] string userIP)
    {
        if (userIP is null)
            return scope;
        scope.SetCustomField(nameof(userIP), userIP, true);
        return scope;
    }

    public static AuditScope WithUserAgent(this AuditScope scope, [CanBeNull] string userAgent)
    {
        if (userAgent is null)
            return scope;
        scope.SetCustomField(nameof(userAgent), userAgent, true);
        return scope;
    }

    public static AuditScope WithUserID(this AuditScope scope, [CanBeNull] IIdentity user) =>
        scope.WithUserID(user?.Name);

    [CLSCompliant(false)]
    public static AuditScope WithHttpContext(this AuditScope scope, [CanBeNull] HttpContext ctx)
    {
        if (ctx is null)
            return scope;

        ctx.Request.Headers.TryGetValue("User-Agent", out var agent);

        var remoteIp = ctx.Connection.RemoteIpAddress?.ToString();
        if (scope.Event is ExchangeAuditEvent auditEvent)
        {
            auditEvent.IP = remoteIp;
            auditEvent.UserAgent = agent.ToString();
            auditEvent.UserId = ctx.User?.Identity?.Name;
            return scope;
        }

        return scope
            .WithUserID(ctx.User?.Identity?.Name)
            .WithUserIP(remoteIp)
            .WithUserAgent(agent.ToString());
    }

    public static AuditScope DiscardIf(this AuditScope scope, bool discard)
    {
        if (discard)
            scope?.Discard();

        return scope;
    }
}
