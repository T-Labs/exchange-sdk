using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealDispute
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
    CreatorAdmitsFault = 10,
    CreatorDeniesFault = 20,
    RespondentAdmitsFault = 30,
    RespondentDeniesFault = 40,
}
