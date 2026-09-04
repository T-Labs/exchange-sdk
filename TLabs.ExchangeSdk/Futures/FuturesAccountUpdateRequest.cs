#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesAccountUpdateRequest
{
    public long FuturesAccountId { get; set; }
    public string? UserId { get; set; }
    public int Leverage { get; set; }
    public string? Name { get; set; }
}
