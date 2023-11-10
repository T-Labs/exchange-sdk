namespace TLabs.ExchangeSdk.Bwp;

public class InvoiceCreateResponse
{
    public long InvoiceId { get; set; }
    public string CardNumber { get; set; }
    public string PaymentMethodKey { get; set; }
    public string ErrorCode { get; set; }
}
