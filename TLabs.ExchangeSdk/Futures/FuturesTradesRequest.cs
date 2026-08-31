#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class FuturesTradesRequest
{
    public string? UserId { get; set; }
    public string? CurrencyPair { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; } = 100;
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }

    public long? FuturesAccountId { get; set; }
}
