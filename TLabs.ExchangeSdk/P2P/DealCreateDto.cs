using System;

namespace TLabs.ExchangeSdk.P2P;

public record DealCreateDto
{
    public Guid OrderId { get; set; }
    public int PaymentSystemId { get; set; }
    public string DealUserId { get; set; }
    public decimal Amount { get; set; }
}
