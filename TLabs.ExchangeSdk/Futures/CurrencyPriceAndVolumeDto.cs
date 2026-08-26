#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class CurrencyPriceAndVolumeDto
{
    public decimal? Price { get; set; }
    public decimal? Price24hAgo { get; set; }
    public decimal? Price1hAgo { get; set; }
    public decimal? Price4hAgo { get; set; }
    public decimal? PriceChangePercentage { get; set; }
    public decimal? Volume24h { get; set; }
    public decimal? Low24h { get; set; }
    public decimal? High24h { get; set; }
    public string CurrencyPairCode { get; set; }
}
