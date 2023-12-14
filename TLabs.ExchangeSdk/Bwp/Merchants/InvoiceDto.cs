using System;

namespace TLabs.ExchangeSdk.Bwp.Merchants;

public class InvoiceDto
{
    public long InvoiceId { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal CryptoAmount { get; set; }
    public decimal FiatAmount { get; set; }
    public string CurrencyCode { get; set; } = "RUB";
    public string CallbackUrl { get; set; }
    public string PaymentMethodKey { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Finished { get; set; }
    public DealStatus Status { get; set; }
}
