using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TLabs.ExchangeSdk.Features.Profeex;

[JsonConverter(typeof(StringEnumConverter))]
public enum ProfeexResourceType
{
    Energy = 0,
    Bandwidth = 1,
}
