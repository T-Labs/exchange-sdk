#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using Newtonsoft.Json;

public class FuturesTransferRequest
{
    /// <summary>Сумма строкой, чтобы не терять точность на JSON-числах</summary>
    [JsonProperty(Required = Required.Always)]
    public string Amount { get; init; } = string.Empty;

    [JsonProperty(Required = Required.Always)]
    public long FuturesAccountId { get; init; }

    [JsonProperty(Required = Required.Always)]
    public string CurrencyCode { get; init; } = string.Empty;
}

/// <summary>Internal-вариант: userId доложен доверенной стороной (фасад/сервис), не клиентом</summary>
public class FuturesTransferInternalRequest : FuturesTransferRequest
{
    [JsonProperty(Required = Required.Always)]
    public string UserId { get; init; } = string.Empty;
}
