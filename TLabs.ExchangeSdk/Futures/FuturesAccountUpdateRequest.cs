#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesAccountUpdateRequest
{
    public long FuturesAccountId { get; set; }
    public string UserId { get; set; } = null!;
    public int Leverage { get; set; }
    public string? Name { get; set; }
}
