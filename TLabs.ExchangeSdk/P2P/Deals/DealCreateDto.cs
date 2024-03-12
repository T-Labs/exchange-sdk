using System;

namespace TLabs.ExchangeSdk.P2P.Deals;

public record DealCreateDto
{
    public Guid OrderId { get; set; }
    public Guid RequisiteId { get; set; }
    public string DealUserId { get; set; }
    public decimal CryptoAmount { get; set; }

    public override string ToString() => $"{nameof(DealCreateDto)}(OrderId:{OrderId}, " +
        $"RequisiteId:{RequisiteId} DealUserId:{DealUserId}, {CryptoAmount})";
}
