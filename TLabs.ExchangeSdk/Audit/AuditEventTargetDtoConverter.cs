using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TLabs.ExchangeSdk.Audit;

internal sealed class AuditEventTargetDtoConverter : JsonConverter<AuditEventTargetDto>
{
    public override AuditEventTargetDto ReadJson(
        JsonReader reader,
        Type objectType,
        AuditEventTargetDto existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var obj = JObject.Load(reader);
        return new AuditEventTargetDto
        {
            SerializedNew = ToJsonString(obj["New"]),
            SerializedOld = ToJsonString(obj["Old"]),
        };
    }

    public override void WriteJson(JsonWriter writer, AuditEventTargetDto value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        WriteField(writer, "New", value?.SerializedNew);
        WriteField(writer, "Old", value?.SerializedOld);
        writer.WriteEndObject();
    }

    private static void WriteField(JsonWriter writer, string name, string value)
    {
        writer.WritePropertyName(name);
        if (value is null)
            writer.WriteNull();
        else
            writer.WriteValue(value);
    }

    private static string ToJsonString(JToken token)
    {
        if (token is null || token.Type == JTokenType.Null)
            return null;

        if (token.Type == JTokenType.String)
            return token.ToString();

        return token.ToString(Formatting.None);
    }
}
