namespace TLabs.ExchangeSdk.P2P;

public class PaymentMethodDto
{
    public int PaymentSystemId { get; set; }
    public string CurrencyCode { get; init; }
    public bool IsActive { get; init; }
}
