using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Bwp;

public class TraderDeal
{
    [Key]
    public Guid Id { get; set; }

    public long InvoiceId { get; set; }

    /// <summary>Ratio between FiatAmount and CryptoAmount taken from garantex.org.</summary>
    public decimal ExchangeRate { get; set; }

    /// <summary> The amount of cryptocurrency to be exhange.
    /// This is calculated based on the current market rate garantex.org and the fiat amount to be exchanged. </summary>
    public decimal CryptoAmount { get; set; }

    /// <summary> The amount of fiat currency to be exchanged for cryptocurrency.
    /// This amount is determined at the created of the trade deal.</summary>
    public decimal FiatAmount { get; set; }

    /// <summary> The current status of the trade deal,
    /// indicating the progress and state of the trade transaction from initiation to completion. </summary>
    public TraderDealStatus Status { get; set; }

    /// <summary> Date and time of merchant payment.
    /// Set at the moment when the merchant confirms that the amount has been sent. </summary>
    public DateTimeOffset DateUserConfirmedPayment { get; set; }

    /// <summary> Date and time when the trader saw the receipt of funds on his details and confirmed the payment.
    /// It may be zero if the trader has not yet confirmed receipt of payment. </summary>
    public DateTimeOffset? DateTraderConfirmedPayment { get; set; }

    /// <summary> The timestamp when the trade deal was either successfully completed and the cryptocurrency was released,
    /// or the deal was canceled. Null if the deal is ongoing. </summary>
    public DateTimeOffset? DateFinished { get; set; }

    /// <summary> Navigation property to the associated Invoice entity.
    /// It contains all financial details related to this trade deal, such as amounts and currency codes. </summary>
    public Invoice Invoice { get; set; }
}

public enum TraderDealStatus
{
    /// <summary> Status indicating the user has confirmed payment, awaiting confirmation from the trader. </summary>
    UserConfirmedPayment = 10,

    /// <summary> Status indicating the trader has confirmed the payment, and the trade is ready to proceed to the next step.</summary>
    TraderConfirmedPayment = 20,

    /// <summary> Status indicating the cryptocurrency has been released to the user, completing the trade deal.</summary>
    CryptoReleased = 30,

    /// <summary> Status indicating the trade deal has been canceled and will not be processed further.</summary>
    Canceled = 40,

    /// <summary> Status indicating there is a dispute over the trade deal, which may require intervention to resolve.</summary>
    Disputed = 50,
}
