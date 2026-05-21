using Newtonsoft.Json;

namespace TLabs.ExchangeSdk.Features.Profeex;

[JsonConverter(typeof(ProfeexEnumConverter))]
public enum ProfeexErrorCode
{
    InvalidAddress = 0,
    InvalidParameters = 1,
    InsufficientBalance = 2,
    DuplicateRequest = 3,
    RateLimitExceeded = 4,
    ServiceUnavailable = 5,
    RequestTimeout = 6,
    ProcessingFailed = 7,
    ConfigurationError = 8,
    UnknownError = 9,
}
