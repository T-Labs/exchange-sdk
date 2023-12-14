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
    New = 10,
    TraderAppointed = 20,
    CryptoFrozen = 30,

    [Description("Пользователь подтвердил оплату.")]
    UserConfirmedPayment = 40,

    [Description("Платеж подтвержден.")]
    TraderConfirmedPayment = 50,

    [Description("Сделка завершена.")]
    CryptoReleased = 60,

    [Description("Открыт спор по сделке.")]
    Disputed = 70,

    [Description("Истекло время подтвержения.")]
    Expired = 80,

    [Description("Сделка закрыта администратором.")]
    AdminClosed = 90,

    CryptoUnfrozen = 100,
}
