namespace TLabs.ExchangeSdk.Bwp;

public class InvoiceCreateRequest
{
    public decimal Amount { get; set; }
    public string CallbackUrl { get; set; }
    public string PaymentMethodKey { get; set; }
}
