using System.Text.Json;
using Audit.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TLabs.ExchangeSdk.Audit;

public static class AuditTargetJson
{
    public static string SerializeAuditEvent(AuditEvent auditEvent)
    {
        PrepareForPersistence(auditEvent);
        return JsonConvert.SerializeObject(auditEvent);
    }

    public static void PrepareForPersistence(AuditEvent auditEvent) =>
        NormalizeTarget(auditEvent?.Target);

    public static object NormalizeTargetValue(object value)
    {
        if (value is null)
            return null;

        if (value is JsonElement element)
        {
            if (element.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
                return null;

            return JToken.Parse(element.GetRawText());
        }

        return value;
    }

    public static string SerializeTargetValue(object value)
    {
        value = NormalizeTargetValue(value);
        if (value is null)
            return null;

        if (value is string s)
            return s;

        if (value is JToken token)
            return token.ToString(Formatting.None);

        return JsonConvert.SerializeObject(value, Formatting.None);
    }

    private static void NormalizeTarget(AuditTarget target)
    {
        if (target is null)
            return;

        if (target.New is not null)
            target.New = NormalizeTargetValue(target.New);
        if (target.Old is not null)
            target.Old = NormalizeTargetValue(target.Old);
    }
}
