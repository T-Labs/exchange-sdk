using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Audit.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TLabs.ExchangeSdk.Audit;

public class ExchangeAuditEvent : AuditEvent
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string IP { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string UserAgent { get; set; }

    public string[] GetValues(bool isNew = true)
    {
        if (Target is null)
            return Array.Empty<string>();

        var value = isNew ? Target.New : Target.Old;
        if (value is null)
            return Array.Empty<string>();

        var valueType = value.GetType();
        if (valueType.IsValueType && valueType.FullName?.Contains("ValueTuple", StringComparison.Ordinal) == true)
        {
            return valueType.GetFields(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(f => f.Name, StringComparer.Ordinal)
                .Select(f => f.GetValue(value)?.ToString() ?? string.Empty)
                .ToArray();
        }

        if (value is ITuple tuple && tuple.Length > 0)
        {
            return Enumerable.Range(0, tuple.Length)
                .Select(i => tuple[i]?.ToString() ?? string.Empty)
                .ToArray();
        }

        if (value is JObject jObject)
            return jObject.Properties().SelectMany(p => FlattenToken(p.Value)).ToArray();
        if (value is JArray jArray)
            return jArray.SelectMany(FlattenToken).ToArray();
        if (value is string str)
            return new[] { str };

        var token = value is JToken jToken
            ? jToken
            : JToken.Parse(JsonConvert.SerializeObject(value));
        if (token.Type == JTokenType.Object)
            return token.Children<JProperty>().SelectMany(p => FlattenToken(p.Value)).ToArray();
        if (token.Type == JTokenType.Array)
            return token.Values().SelectMany(FlattenToken).ToArray();

        return new[] { token.ToString() };
    }

    private static string[] FlattenToken(JToken token)
    {
        switch (token.Type)
        {
            case JTokenType.String:
            case JTokenType.Integer:
            case JTokenType.Boolean:
            case JTokenType.Float:
            case JTokenType.Date:
            case JTokenType.Guid:
            case JTokenType.Uri:
                return new[] { token.ToString() };
            case JTokenType.Property:
                return token.Values().SelectMany(FlattenToken).ToArray();
            case JTokenType.Object:
                return token.Children().SelectMany(FlattenToken).ToArray();
            case JTokenType.Array:
                return token.Values().SelectMany(FlattenToken).ToArray();
            case JTokenType.Null:
            case JTokenType.Undefined:
                return Array.Empty<string>();
            default:
                return new[] { token.ToString() };
        }
    }
}
