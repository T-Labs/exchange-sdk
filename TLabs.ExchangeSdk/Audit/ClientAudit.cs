using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Audit;

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
            ? JsonConvert.DeserializeObject(json) ?? json
            : auditEvent;

        try
        {
            var response = await $"{EventsBase}/{eventType}".InternalApi()
                .WithTimeout(InjectTimeoutSeconds)
                .AllowAnyHttpStatus()
                .PostJsonAsync(payload, cancellationToken: cancellationToken);

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

    public async Task<AuditEventsPageDto> GetAllAsync(
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
                var statusCode = (int)response.ResponseMessage.StatusCode;
                _logger.LogWarning("Audit get-all failed: HTTP {StatusCode}", statusCode);
                return FailedPage($"Audit service returned HTTP {statusCode}.");
            }

            return JsonConvert.DeserializeObject<AuditEventsPageDto>(await response.GetStringAsync())
                ?? FailedPage("Audit service returned an empty response.");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Audit get-all failed");
            return FailedPage("Failed to load audit events from the audit service.");
        }
    }

    public async Task<AuditEventsPageDto> GetByUserIdAsync(
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
                var statusCode = (int)response.ResponseMessage.StatusCode;
                _logger.LogWarning(
                    "Audit get-by-user failed for {UserId}: HTTP {StatusCode}",
                    userId,
                    statusCode);
                return FailedPage($"Audit service returned HTTP {statusCode}.");
            }

            return JsonConvert.DeserializeObject<AuditEventsPageDto>(await response.GetStringAsync())
                ?? FailedPage("Audit service returned an empty response.");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Audit get-by-user failed for {UserId}", userId);
            return FailedPage("Failed to load audit events from the audit service.");
        }
    }

    private static AuditEventsPageDto FailedPage(string message) =>
        new()
        {
            Success = false,
            ErrorMessage = message,
        };
}

internal static class ClientAuditExtensions
{
    public static IFlurlRequest SetAuditQueryOptions(this IFlurlRequest request, AuditQueryOptions filter)
    {
        if (filter is null)
            return request;

        if (filter.Sorts.HasValue())
            request = request.SetQueryParam(nameof(filter.Sorts), filter.Sorts);
        if (filter.Filters.HasValue())
            request = request.SetQueryParam(nameof(filter.Filters), filter.Filters);
        if (filter.UserId.HasValue())
            request = request.SetQueryParam("userId", filter.UserId.Trim());
        if (filter.Page.HasValue)
            request = request.SetQueryParam(nameof(filter.Page), filter.Page.Value);
        if (filter.PageSize.HasValue)
            request = request.SetQueryParam(nameof(filter.PageSize), filter.PageSize.Value);

        return request;
    }
}
