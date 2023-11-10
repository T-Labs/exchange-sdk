using System;

namespace TLabs.ExchangeSdk.Bwp;

public class Invoice
{
    public long BwpInvoiceId { get; set; }
    public long MerchantId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = "RUB";
    public string CallbackUrl { get; set; }
    public string PaymentMethodCode { get; set; }

    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Expires { get; set; }

    /// <summary>
    /// field for external payment system invoices
    /// </summary>
    public string? PaymentSystemInvoiceId { get; set; }

    /// <summary>
    /// fields for widget invoices
    /// </summary>
    public string? PaymentUrl { get; set; }

    public string? RedirectUrl { get; set; }

    public bool IsExpired => Expires < DateTimeOffset.UtcNow;
}
