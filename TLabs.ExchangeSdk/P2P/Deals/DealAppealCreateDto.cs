using System;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealAppealCreateDto
{
    public Guid DealId { get; set; }
    public string CreatorUserId { get; set; }
    public string Cause { get; set; }

    public override string ToString()
    {
        return $" {nameof(DealAppealCreateDto)}(DealId: {DealId}, CreatorUserId: {CreatorUserId}, Cause: {Cause})";
    }
}
