#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesOrderTakeProfitRequest
{
    public string OrderId { get; set; } = null!;
    public decimal? TakeProfit { get; set; }
    public string? UserId { get; set; }
}
