using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Audit
{
    public class ClientAudit : IClientAudit
    {
        private const string EventsBase = "audit/events";
        private const int InjectTimeoutSeconds = 5;
        private const int ReadTimeoutSeconds = 20;
        private readonly ILogger _logger;

        public ClientAudit(ILogger<ClientAudit> logger)
        {
            _logger = logger;
        }

        public async Task<string> InjectAsync(
            string eventType,
            object auditEvent,
            CancellationToken cancellationToken = default)
        {
            var payload = auditEvent is string json
                ? json
                : JsonConvert.SerializeObject(auditEvent);

            try
            {
                var response = await $"{EventsBase}/{eventType}".InternalApi()
                    .WithTimeout(InjectTimeoutSeconds)
                    .AllowAnyHttpStatus()
                    .PostJsonAsync(payload, cancellationToken);

                if (!response.ResponseMessage.IsSuccessStatusCode)
                {
                    _logger.LogWarning(
                        "Audit inject failed for {EventType}: HTTP {StatusCode}",
                        eventType,
                        (int)response.ResponseMessage.StatusCode);
                    return string.Empty;
                }

                return await response.GetStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Audit inject failed for {EventType}", eventType);
                return string.Empty;
            }
        }

        public async Task<List<AuditEventDto>> GetAllAsync(
            AuditQueryOptions filter = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await EventsBase.InternalApi()
                    .WithTimeout(ReadTimeoutSeconds)
                    .AllowAnyHttpStatus()
                    .SetAuditQueryOptions(filter)
                    .GetAsync(cancellationToken: cancellationToken);

                if (!response.ResponseMessage.IsSuccessStatusCode)
                {
                    _logger.LogWarning(
                        "Audit get-all failed: HTTP {StatusCode}",
                        (int)response.ResponseMessage.StatusCode);
                    return new List<AuditEventDto>();
                }

                return JsonConvert.DeserializeObject<List<AuditEventDto>>(await response.GetStringAsync())
                    ?? new List<AuditEventDto>();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Audit get-all failed");
                return new List<AuditEventDto>();
            }
        }

        public async Task<List<AuditEventDto>> GetByUserIdAsync(
            string userId,
            AuditQueryOptions filter = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await $"{EventsBase}/by-user/{userId}".InternalApi()
                    .WithTimeout(ReadTimeoutSeconds)
                    .AllowAnyHttpStatus()
                    .SetAuditQueryOptions(filter)
                    .GetAsync(cancellationToken: cancellationToken);

                if (!response.ResponseMessage.IsSuccessStatusCode)
                {
                    _logger.LogWarning(
                        "Audit get-by-user failed for {UserId}: HTTP {StatusCode}",
                        userId,
                        (int)response.ResponseMessage.StatusCode);
                    return new List<AuditEventDto>();
                }

                return JsonConvert.DeserializeObject<List<AuditEventDto>>(await response.GetStringAsync())
                    ?? new List<AuditEventDto>();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Audit get-by-user failed for {UserId}", userId);
                return new List<AuditEventDto>();
            }
        }
    }

    internal static class ClientAuditExtensions
    {
        public static IFlurlRequest SetAuditQueryOptions(this IFlurlRequest request, AuditQueryOptions filter)
        {
            if (filter is null)
                return request;

            if (filter.Sorts != null)
                request = request.SetQueryParam(nameof(filter.Sorts), filter.Sorts);
            if (filter.Filters != null)
                request = request.SetQueryParam(nameof(filter.Filters), filter.Filters);
            if (filter.Page.HasValue)
                request = request.SetQueryParam(nameof(filter.Page), filter.Page.Value);
            if (filter.PageSize.HasValue)
                request = request.SetQueryParam(nameof(filter.PageSize), filter.PageSize.Value);

            return request;
        }
    }
}
