namespace TLabs.ExchangeSdk.P2P;

public class PaymentMethod
{
    public int PaymentSystemId { get; set; }
    public string CurrencyCode { get; set; }
    public PaymentSystem PaymentSystem { get; set; }
    public PaymentCurrency PaymentCurrency { get; set; }
    public bool IsActive { get; set; }
}
