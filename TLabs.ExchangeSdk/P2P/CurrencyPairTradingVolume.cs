namespace TLabs.ExchangeSdk.P2P;

public class CurrencyPairTradingVolume
{
    public string ExchangeCurrencyCode { get; set; }
    public string PaymentCurrencyCode { get; set; }
    public string TotalExchangeAmount { get; set; }
    public string TotalPaymentAmount { get; set; }
    public decimal TotalAmountInUsdt { get; set; }
}
