using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.Bwp;

public class Invoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long InvoiceId { get; set; }

    public long MerchantId { get; set; }
    public Merchant Merchant { get; set; }

    /// <summary>Ratio between FiatAmount and CryptoAmount taken from garantex.org.</summary>
    public decimal ExchangeRate { get; set; }

    /// <summary> The amount of crypto currency to be exchange.
    /// This is calculated based on the current market rate garantex.org and the fiat amount to be exchanged. </summary>
    public decimal CryptoAmount { get; set; }

    /// <summary> The amount of fiat currency to be exchanged for crypto currency.
    /// FiatAmount in fiat for which the invoice was issued</summary>
    public decimal FiatAmount { get; set; }

    /// <summary> The three-letter ISO currency code representing the type of currency used in the invoice amount,
    /// with a default value of "RUB" (Russian Ruble).</summary>
    public string CurrencyCode { get; set; } = "RUB";

    /// <summary>
    /// The URL where payment notifications will be sent upon processing of the invoice.
    /// </summary>
    public string CallbackUrl { get; set; }

    /// <summary>
    /// A unique key that identifies the payment method to be used for this invoice,
    /// which could correspond to a specific bank or financial institution, such as "Sberbank".</summary>
    public string PaymentMethodKey { get; set; }

    /// <summary>
    /// The unique identifier corresponding to the payment details provided by the trader,
    /// which are necessary for completing the transaction. </summary>
    public Guid? TraderRequisiteId { get; set; }

    /// <summary>
    /// Navigation property to the TraderRequisite entity,
    /// providing all the necessary payment details associated with the trader for this invoice. </summary>
    public TraderRequisite TraderRequisite { get; set; }

    /// <summary> The exact date and time when the invoice was issued,
    /// typically set to the current date and time when the invoice record is created. </summary>
    public DateTimeOffset Created { get; set; }

    /// <summary> An optional identifier that can be used to correlate this invoice with an entry in an external payment system.</summary>
    public string? PaymentSystemInvoiceId { get; set; }

    /// <summary> An optional URL where the customer can be directed to make a payment,
    /// usually associated with an online payment gateway or widget. </summary>
    public string? PaymentUrl { get; set; }

    /// <summary> An optional URL where the customer will be redirected after a successful payment,
    /// which could be a thank-you page or order summary page. </summary>
    public string? RedirectUrl { get; set; }
    public List<DealEvent> DealEvents { get; set; }
}
