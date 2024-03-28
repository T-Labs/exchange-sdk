namespace TLabs.ExchangeSdk.P2P;

public class CurrencyPairTradingVolume
{
    public string PaymentCurrencyCode { get; set; }
    public string ExchangeCurrencyCode { get; set; }
    public decimal TotalAmountInUsdt { get; set; }
}
