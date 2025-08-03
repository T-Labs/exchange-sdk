namespace TLabs.ExchangeSdk.CryptoAdapters.Tron;

public class ExternalDelegateRequest
{
    public bool IsUndelegate { get; set; } = false;
    public string TargetAddress { get; set; }
    public decimal TrxToDelegate { get; set; }
}
