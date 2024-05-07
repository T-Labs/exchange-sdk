using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealCancellationDispute
{
    [Key]
    public Guid Id { get; set; }

    public Guid DealId { get; set; }
    public Deal Deal { get; set; }
    public string CreatorUserId { get; set; }
    public string RespondentUserId { get; set; }
    public string Cause { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateCompleted { get; set; }
    public DealDisputeStatus Status { get; set; }
}

public enum DealDisputeStatus
{
    InProgress = 10,
    CreatorAcknowledgedFault = 20,
    CreatorChallenged = 30,
    RespondentAgreed = 40,
    RespondentDisputed = 50, 
}
