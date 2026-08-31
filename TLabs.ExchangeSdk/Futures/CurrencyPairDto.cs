#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;
using System.Collections.Generic;

public class CurrencyPairDto
{
    public string CurrencyPairCode { get; set; } = null!;
    public string QuoteCurrency { get; set; } = null!;
    public string BaseCurrency { get; set; } = null!;
    public bool IsActive { get; set; }
    public bool ShowOnBanners { get; set; }
    public bool ShowOnMarkets { get; set; }
    public CurrencyPairType CurrencyPairType { get; set; }
    public FuturesPairSubCategory SubCategory { get; set; }
    public Dictionary<string, decimal> IndexComponentWeight { get; set; } = new();
    public Dictionary<string, decimal> IndexComponentStartPrices { get; set; } = new();
    public string Description { get; set; } = null!;
    public string? ShortDescription { get; set; }
    public int BasePricePrecision { get; set; }
    public int QuantityPrecision { get; set; }
    public int QuotePricePrecision { get; set; }
    public int AmountChangeCoefficient { get; set; }
    public decimal MinOrderSize { get; set; }
    public decimal CommissionRate { get; set; }
    public int MaxLeverage { get; set; }
    public decimal MakerFeeRate { get; set; }
    public decimal TakerFeeRate { get; set; }
    public decimal ContractValue { get; set; }
    public decimal FundingRate { get; set; }
    public decimal LotSize { get; set; }
    public decimal LotStep { get; set; } = 1m;
    public DateTime? FundingRateStartTimestamp { get; set; }
    public DateTime? FundingRateFinishTimestamp { get; set; }
    public string ImageBlobId { get; set; } = null!;
    public string? BannerBackgroundImageBlobId { get; set; }

    public double TotalSecondsToApplyFundingRate =>
        FundingRateFinishTimestamp.HasValue && FundingRateStartTimestamp.HasValue
            ? (FundingRateFinishTimestamp - DateTime.UtcNow).Value.TotalSeconds
            : 0;
}
