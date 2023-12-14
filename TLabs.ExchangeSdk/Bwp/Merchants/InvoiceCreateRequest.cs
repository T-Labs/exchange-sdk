namespace TLabs.ExchangeSdk.Bwp.Merchants;

public class InvoiceCreateRequest
{
    public decimal Amount { get; set; }
    public string CallbackUrl { get; set; }
    public string PaymentMethodKey { get; set; }
}
