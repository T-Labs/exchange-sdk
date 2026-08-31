#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesOrdersCancelAllRequest
{
    public string UserId { get; set; } = null!;
    public long FuturesAccountId { get; set; }
}
