using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealDisputeCreateDto
{
    [Required]
    public Guid DealId { get; set; }

    [Required]
    public string CreatorUserId { get; set; }

    [Required]
    public string Cause { get; set; }

    [Required]
    public DealDisputeStatus Status { get; set; }

    public override string ToString()
    {
        return $" {nameof(DealDisputeCreateDto)}(DealId: {DealId}, CreatorUserId: {CreatorUserId}, Cause: {Cause})";
    }
}
