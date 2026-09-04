#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesAccountCreateRequest
{
    public string? UserId { get; set; }
    public string CurrencyCode { get; set; } = null!;
    public int Leverage { get; set; }
    public string Name { get; set; } = null!;
    public bool SkipDefaultCopySlaveEnsure { get; set; }

    /// <summary>Copy-счета создаются вне лимита торговых счетов.</summary>
    public bool SkipAccountsLimit { get; set; }
}
