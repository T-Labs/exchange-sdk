using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class ActionTask
{
    [Key]
    public long Id { get; set; }

    public int Ordering { get; set; }
    public string Description { get; set; }
    public string ActionUrl { get; set; }
    public PlatformType Platform { get; set; }
    public List<UserTask> UserTasks { get; set; }
    public decimal RewardAmount { get; set; }
    public long TenantId { get; set; }
    public bool IsActive { get; set; }
    public Region? Region { get; set; }
    public int? AvailableDayNumber { get; set; }

    /// <summary>Only available for Platform.Telegram and when our bot is admin in the channel</summary>
    public bool CheckTgChannelSubscribed { get; set; }
}

public enum PlatformType
{
    Youtube = 10,
    Telegram = 20,
    X = 30,
    Discord = 40
}
