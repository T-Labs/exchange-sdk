using System;
using System.Text;
using Newtonsoft.Json;

namespace TLabs.ExchangeSdk.Features.Profeex;

/// <summary>
/// Maps C# PascalCase enum members to the SCREAMING_SNAKE_CASE strings used by the ProFeeX API
/// (ACTIVE, DUPLICATE_REQUEST, BANDWIDTH, USDT, ...). Acronyms like TRX/USDT stay as-is.
/// </summary>
public class ProfeexEnumConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        var underlying = Nullable.GetUnderlyingType(objectType) ?? objectType;
        return underlying.IsEnum;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }
        writer.WriteValue(ToScreamingSnake(value.ToString()));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;

        var enumType = Nullable.GetUnderlyingType(objectType) ?? objectType;
        var raw = reader.Value?.ToString();
        if (string.IsNullOrEmpty(raw)) return null;

        var normalized = FromScreamingSnake(raw);
        return Enum.Parse(enumType, normalized, ignoreCase: true);
    }

    public static string ToScreamingSnake(string pascal)
    {
        if (string.IsNullOrEmpty(pascal)) return pascal;
        var sb = new StringBuilder(pascal.Length + 4);
        for (int i = 0; i < pascal.Length; i++)
        {
            char c = pascal[i];
            if (i > 0 && char.IsUpper(c) && !char.IsUpper(pascal[i - 1]))
                sb.Append('_');
            sb.Append(char.ToUpperInvariant(c));
        }
        return sb.ToString();
    }

    public static string FromScreamingSnake(string raw)
    {
        var sb = new StringBuilder(raw.Length);
        bool capitalizeNext = true;
        foreach (var c in raw)
        {
            if (c == '_')
            {
                capitalizeNext = true;
                continue;
            }
            sb.Append(capitalizeNext ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c));
            capitalizeNext = false;
        }
        return sb.ToString();
    }
}
