using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TLabs.ExchangeSdk.Features.Profeex;

[JsonConverter(typeof(StringEnumConverter))]
public enum ProfeexCurrency
{
    TRX = 0,
    USDT = 1,
}
