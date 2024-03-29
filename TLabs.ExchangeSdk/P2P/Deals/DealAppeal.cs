using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealAppeal
{
    [Key]
    public Guid Id { get; set; }

    public Guid DealId { get; set; }
    public Deal Deal { get; set; }
    public string CreatorUserId { get; set; }
    public string AdminUserId { get; set; }
    public string Cause { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateCompleted { get; set; }
    public AppealStatus Status { get; set; }
}

public enum AppealStatus
{
    InProgress = 10,
    SetPaymentSystemConfirmed = 20,
    SetCanceled = 30,
}
