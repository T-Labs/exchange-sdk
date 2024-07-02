using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class UserTask
{
    [Key]
    public long Id { get; set; }

    public long ActionTaskId { get; set; }
    public ActionTask ActionTask { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public DateTimeOffset? DateCompleted { get; set; }
    public DateTimeOffset? DataClaimed { get; set; }
    public UserTaskStatus Status { get; set; }
}

public enum UserTaskStatus
{
    NotStarted = 0,
    Completed = 10,
    Claimed = 20,
}
