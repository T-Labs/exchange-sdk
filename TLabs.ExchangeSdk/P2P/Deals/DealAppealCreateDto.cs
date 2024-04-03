using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealAppealCreateDto
{
    [Required]
    public Guid DealId { get; set; }

    public string CreatorUserId { get; set; }

    [Required]
    public string Cause { get; set; }

    public override string ToString()
    {
        return $" {nameof(DealAppealCreateDto)}(DealId: {DealId}, CreatorUserId: {CreatorUserId}, Cause: {Cause})";
    }
}
