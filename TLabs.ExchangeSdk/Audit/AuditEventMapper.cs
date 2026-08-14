using System;
using Audit.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TLabs.ExchangeSdk.Audit;

[CLSCompliant(false)]
public static class AuditEventMapper
{
    public static AuditEventDto ToDto(ExchangeAuditEvent auditEvent, string rawData = null)
    {
        if (auditEvent is null)
            return null;

        var targetNew = ExtractTargetFromRaw(rawData, "New")
            ?? AuditTargetJson.SerializeTargetValue(auditEvent.Target?.New);
        var targetOld = ExtractTargetFromRaw(rawData, "Old")
            ?? AuditTargetJson.SerializeTargetValue(auditEvent.Target?.Old);

        return new AuditEventDto
        {
            EventType = auditEvent.EventType,
            UserId = auditEvent.UserId,
            IP = auditEvent.IP,
            UserAgent = auditEvent.UserAgent,
            StartDate = ToOffset(auditEvent.StartDate),
            EndDate = auditEvent.EndDate.HasValue ? ToOffset(auditEvent.EndDate.Value) : null,
            Duration = auditEvent.Duration,
            EventData = targetNew ?? targetOld,
            Target = targetNew is null && targetOld is null
                ? null
                : new AuditEventTargetDto
                {
                    SerializedNew = targetNew,
                    SerializedOld = targetOld,
                },
        };
    }

    public static string ExtractTargetFromRaw(string rawData, string field)
    {
        if (string.IsNullOrWhiteSpace(rawData))
            return null;

        try
        {
            if (JObject.Parse(rawData)["Target"] is not JObject target)
                return null;

            var token = target[field];
            if (token is null || token.Type == JTokenType.Null)
                return null;

            return token.Type == JTokenType.String
                ? token.ToString()
                : token.ToString(Formatting.None);
        }
        catch (Exception ex) when (ex is Newtonsoft.Json.JsonException or InvalidOperationException)
        {
            return null;
        }
    }

    public static string SerializeTargetNew(AuditEvent auditEvent) =>
        auditEvent is ExchangeAuditEvent exchangeAuditEvent
            ? AuditTargetJson.SerializeTargetValue(exchangeAuditEvent.Target?.New)
            : null;

    private static DateTimeOffset ToOffset(DateTime value)
    {
        if (value.Kind == DateTimeKind.Unspecified)
            value = DateTime.SpecifyKind(value, DateTimeKind.Utc);

        return new DateTimeOffset(value.ToUniversalTime());
    }
}
