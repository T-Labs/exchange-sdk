#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class FuturesCandlesRequest
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string CurrencyPair { get; set; } = null!;
    public CandleTimePeriod CandleTimePeriod { get; set; }
}
