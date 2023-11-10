using System;

namespace TLabs.ExchangeSdk.Bwp;

public class Invoice
{
    public long BwpInvoiceId { get; set; }
    public long MerchantId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public string CallbackUrl { get; set; }
    public string PaymentMethodCode { get; set; }

    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Expires { get; set; }

    public string PaymentSystemInvoiceId { get; set; }
    public string PaymentUrl { get; set; }

    public string RedirectUrl { get; set; }

    public bool IsExpired { get; set; }
}
