#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesOrderCancelRequest
{
    public string Id { get; set; } = null!;
    public bool IsMarket { get; set; }
    public decimal? Amount { get; set; }
    public decimal? LimitPrice { get; set; }
    public bool IsLiquidation { get; set; }

    public string UserId { get; set; } = null!;
}
