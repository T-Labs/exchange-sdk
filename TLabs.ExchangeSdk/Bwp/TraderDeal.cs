using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Bwp;

public class TraderDeal
{
    [Key]
    public long Id { get; set; }

    public long InvoiceId { get; set; }

    /// <summary>Ratio between FiatAmount and CryptoAmount taken from garantex.org.</summary>
    public decimal ExchangeRate { get; set; }

    /// <summary> The amount of crypto currency to be exchange.
    /// This is calculated based on the current market rate garantex.org and the fiat amount to be exchanged. </summary>
    public decimal CryptoAmount { get; set; }

    /// <summary> The amount of fiat currency to be exchanged for crypto currency.
    /// This is the actual amount for the trades. May differ from FiatAmount in invoice </summary>
    public decimal FiatAmount { get; set; }

    /// <summary> Date and time of created.
    /// Set at the moment when the merchant confirms that the amount has been sent. </summary>
    public DateTimeOffset DateCreated { get; set; }

    /// <summary> Navigation property to the associated Invoice entity.
    /// It contains all financial details related to this trade deal, such as amounts and currency codes. </summary>
    public Invoice Invoice { get; set; }

    public List<DealEvent> DealEvents { get; set; }
}
