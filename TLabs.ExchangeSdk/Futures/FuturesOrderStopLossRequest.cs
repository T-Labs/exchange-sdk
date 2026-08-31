#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesOrderStopLossRequest
{
    public string OrderId { get; set; } = null!;
    public decimal? StopLoss { get; set; }
    public string UserId { get; set; } = null!;
}
