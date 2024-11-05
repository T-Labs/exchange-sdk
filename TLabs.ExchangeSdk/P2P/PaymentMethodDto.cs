namespace TLabs.ExchangeSdk.P2P;

public class PaymentMethodDto
{
    public int PaymentSystemId { get; set; }
    public string CurrencyCode { get; set; }
    public bool IsActive { get; set; }
}
