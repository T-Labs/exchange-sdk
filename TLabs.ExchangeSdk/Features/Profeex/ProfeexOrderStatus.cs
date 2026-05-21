using Newtonsoft.Json;

namespace TLabs.ExchangeSdk.Features.Profeex;

[JsonConverter(typeof(ProfeexEnumConverter))]
public enum ProfeexOrderStatus
{
    Queued = 0,
    Pending = 1,
    Processing = 2,
    Active = 3,
    Completed = 4,
    Failed = 5,
    Cancelled = 6,
    Unknown = 7,
}
