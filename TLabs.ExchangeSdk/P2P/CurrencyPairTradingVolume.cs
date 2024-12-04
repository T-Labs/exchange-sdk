namespace TLabs.ExchangeSdk.P2P;

public class CurrencyPairTradingVolume
{
    public string ExchangeCurrencyCode { get; set; }
    public string PaymentCurrencyCode { get; set; }
    public decimal TotalExchangeAmount { get; set; }
    public decimal TotalPaymentAmount { get; set; }
    public decimal TotalAmountInUsdt { get; set; }
}
