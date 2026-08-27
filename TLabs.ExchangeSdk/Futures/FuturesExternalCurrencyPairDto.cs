#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class FuturesExternalCurrencyPairDto
{
    public int Id { get; set; }
    public string Symbol { get; set; } = null!;
    public bool IsActive { get; set; }
    public decimal MinOrderSize { get; set; }
    public int BasePricePrecision { get; set; }
    public int QuantityPrecision { get; set; }
    public int QuotePricePrecision { get; set; }
    public decimal ContractValue { get; set; }
    public decimal FundingRate { get; set; }
    public decimal IndexPrice { get; set; }
    public decimal? OpenInterest { get; set; }
    public decimal? OpenInterestUsdt { get; set; }
    public decimal LotSize { get; set; }
    public DateTime? FundingRateStartTimestamp { get; set; }
    public DateTime? FundingRateFinishTimestamp { get; set; }
}
