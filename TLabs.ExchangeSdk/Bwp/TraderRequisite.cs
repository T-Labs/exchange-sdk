using System;

namespace TLabs.ExchangeSdk.Bwp;

public class TraderRequisite
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string CardNumber { get; set; }
    public string PaymentMethodKey { get; set; }
    public TraderPaymentMethod PaymentMethod { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public bool IsActive { get; set; }
}
