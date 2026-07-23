using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Audit
{
    public class ClientAudit : IClientAudit
    {
        private const string EventsBase = "audit/events";

        public async Task<string> InjectAsync(string eventType, object auditEvent)
        {
            var payload = auditEvent is string json
                ? json
                : JsonConvert.SerializeObject(auditEvent);
            return await $"{EventsBase}/{eventType}".InternalApi()
                .WithTimeout(20)
                .AllowAnyHttpStatus()
                .PostJsonAsync(payload)
                .ReceiveString()
                .ContinueWith(task => task.IsFaulted ? string.Empty : task.Result);
        }

        public async Task<List<AuditEventDto>> GetAllAsync(AuditQueryOptions filter = null)
        {
            var result = await EventsBase.InternalApi()
                .WithTimeout(20)
                .AllowAnyHttpStatus()
                .SetAuditQueryOptions(filter)
                .GetJsonAsync<List<AuditEventDto>>();
            return result ?? new List<AuditEventDto>();
        }

        public async Task<List<AuditEventDto>> GetByUserIdAsync(string userId, AuditQueryOptions filter = null)
        {
            var result = await $"{EventsBase}/by-user/{userId}".InternalApi()
                .WithTimeout(20)
                .AllowAnyHttpStatus()
                .SetAuditQueryOptions(filter)
                .GetJsonAsync<List<AuditEventDto>>();
            return result ?? new List<AuditEventDto>();
        }
    }

    internal static class ClientAuditExtensions
    {
        public static IFlurlRequest SetAuditQueryOptions(this IFlurlRequest request, AuditQueryOptions filter)
        {
            if (filter is null)
                return request;

            return request.SetQueryParam(nameof(filter.Sorts), filter.Sorts)
                .SetQueryParam(nameof(filter.Filters), filter.Filters)
                .SetQueryParam(nameof(filter.Page), filter.Page)
                .SetQueryParam(nameof(filter.PageSize), filter.PageSize);
        }
    }
}
