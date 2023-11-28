using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Bwp;

public class DealEvent
{
    [Key]
    public Guid EventId { get; set; }
    public long InvoiceId { get; set; }
    public DealStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public long TraderDealId { get; set; }
    public TraderDeal TraderDeal { get; set; }
}

public enum DealStatus
{
    TraderAppointed = 10,
    CryptoFrozen = 20,
    UserConfirmedPayment = 30,
    TraderConfirmedPayment = 40,
    CryptoReleased = 50,
    Disputed = 60,
    Expired = 70,
    AdminClosed = 80,
    CryptoUnfrozen = 90,
}
