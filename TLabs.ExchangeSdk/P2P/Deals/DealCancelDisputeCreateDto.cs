using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealCancelDisputeCreateDto
{
    [Required]
    public Guid DealId { get; set; }

    public string CreatorUserId { get; set; }

    [Required]
    public string Cause { get; set; }

    [Required]
    public DealCancelDisputeStatus Status { get; set; }

    public override string ToString()
    {
        return $" {nameof(DealCancelDisputeCreateDto)}(DealId: {DealId}, CreatorUserId: {CreatorUserId}, Cause: {Cause})";
    }
}
