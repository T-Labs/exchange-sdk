using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Bwp;

public class DealEvent
{
    [Key]
    public Guid EventId { get; set; }
    public long InvoiceId { get; set; }
    public DealStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public Invoice Invoice { get; set; }
    public TraderDeal? TraderDeal { get; set; }

    public DealEvent()
    {
    }

    public DealEvent(long invoiceId, DealStatus status)
    {
        InvoiceId = invoiceId;
        Status = status;

    }
}

public enum DealStatus
{
    TraderAppointed = 10,
    CryptoFrozen = 20,

    [Description("Пользователь подтвердил оплату.")]
    UserConfirmedPayment = 30,

    [Description("Платеж подтвержден.")]
    TraderConfirmedPayment = 40,

    [Description("Сделка завершена.")]
    CryptoReleased = 50,

    [Description("Открыт спор по сделке.")]
    Disputed = 60,

    [Description("Истекло время подтвержения.")]
    Expired = 70,

    [Description("Сделка закрыта администратором.")]
    AdminClosed = 80,

    CryptoUnfrozen = 90,
}
