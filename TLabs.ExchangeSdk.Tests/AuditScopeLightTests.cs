using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using TLabs.ExchangeSdk.Audit;

namespace TLabs.ExchangeSdk.Tests
{
    public class AuditScopeLightTests
    {
        [SetUp]
        public void SetUp()
        {
            AuditScopeLight.IsAuditActive = true;
        }

        [Test]
        public async Task Track_AfterAwait_UsesCallerName_NotRuntimeFrame()
        {
            var eventType = await TrackAfterAwait();

            Assert.That(eventType, Does.Contain("track:after:await"));
            Assert.That(eventType, Does.Not.Contain("state:machine"));
            Assert.That(eventType, Does.Not.Contain("executor"));
            Assert.That(eventType, Does.Not.Contain("box"));
        }

        [Test]
        public void Track_ExplicitEventType_IsUsedAsIs()
        {
            using var scope = AuditScopeLight.Track(null, "helpdesk:reply", () => new { ticket = 1 });

            Assert.AreEqual("helpdesk:reply", scope.EventType);
        }

        [Test]
        public void WithHttpContext_CopiesIpUserAgentAndUserId()
        {
            var ctx = new DefaultHttpContext();
            ctx.Connection.RemoteIpAddress = IPAddress.Parse("189.74.123.236");
            ctx.Request.Headers["User-Agent"] = "Mozilla/5.0 TestAgent";
            ctx.User = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "admin-user-id"),
            }, "test"));

            using var scope = AuditScopeLight.Track(ctx, "deposits:admin-deposit", () => new { Amount = 1m });
            var auditEvent = (ExchangeAuditEvent)scope.Event;

            Assert.AreEqual("189.74.123.236", auditEvent.IP);
            Assert.AreEqual("Mozilla/5.0 TestAgent", auditEvent.UserAgent);
            Assert.AreEqual("admin-user-id", auditEvent.UserId);
        }

        [Test]
        public void WithHttpContext_FallsBackToXForwardedFor_WhenRemoteIpMissing()
        {
            var ctx = new DefaultHttpContext();
            ctx.Request.Headers["X-Forwarded-For"] = "10.1.2.3, 10.9.8.7";
            ctx.Request.Headers["User-Agent"] = "ForwardedAgent";

            using var scope = AuditScopeLight.Track(ctx, "helpdesk:reply", () => new { });
            var auditEvent = (ExchangeAuditEvent)scope.Event;

            Assert.AreEqual("10.1.2.3", auditEvent.IP);
            Assert.AreEqual("ForwardedAgent", auditEvent.UserAgent);
        }

        [Test]
        public void WithHttpContext_PrefersRemoteIp_WhenXForwardedForPresent()
        {
            var ctx = new DefaultHttpContext();
            ctx.Connection.RemoteIpAddress = IPAddress.Parse("10.0.0.1");
            ctx.Request.Headers["X-Forwarded-For"] = "189.74.123.236, 10.0.0.1";

            using var scope = AuditScopeLight.Track(ctx, "deposits:admin-deposit", () => new { Amount = 1m });
            var auditEvent = (ExchangeAuditEvent)scope.Event;

            Assert.AreEqual("10.0.0.1", auditEvent.IP);
        }

        [Test]
        public void Track_DepthTwo_UsesOuterCaller()
        {
            var eventType = InnerTrackHelper();

            Assert.That(eventType, Does.Contain("uses:outer:caller"));
            Assert.That(eventType, Does.Not.Contain("inner:track:helper"));
            Assert.That(eventType, Does.Not.Contain("audit:scope:light:track"));
        }

        [Test]
        public void WithUserIP_SetsExchangeAuditEventIp()
        {
            using var scope = AuditScopeLight.Track(null, "staking:create-stake-by-admin", () => new { Amount = 2m })
                .WithUserID("admin-1")
                .WithUserIP("8.8.8.8")
                .WithUserAgent("BlazorCircuit");
            var auditEvent = (ExchangeAuditEvent)scope.Event;

            Assert.AreEqual("admin-1", auditEvent.UserId);
            Assert.AreEqual("8.8.8.8", auditEvent.IP);
            Assert.AreEqual("BlazorCircuit", auditEvent.UserAgent);
        }

        private async Task<string> TrackAfterAwait()
        {
            await Task.Yield();
            using var scope = AuditScopeLight.Track(null);
            return scope.EventType;
        }

        private string InnerTrackHelper()
        {
            using var scope = AuditScopeLight.Track(null, trackDepth: 2);
            return scope.EventType;
        }
    }
}
