using System;
using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardPhysicalOrderStatusDto
{
    public Guid CardId { get; set; }
    public Guid OrderId { get; set; }
    public PaymentCardStatus CardStatus { get; set; }
    public PaymentCardPhysicalOrderStatus OrderStatus { get; set; }
    public bool CanActivate { get; set; }
    public string TrackingNumber { get; set; }
}
