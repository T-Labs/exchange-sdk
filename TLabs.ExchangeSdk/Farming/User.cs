using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class User
{
    [Key]
    public long Id { get; set; }

    public long TenantId { get; set; }

    public string UserName { get; set; }
    public long TgUserId { get; set; }
    public string? AvatarImageId { get; set; }

    public DateTimeOffset? DateFarmingStarted { get; set; }

    public int MiniGameCounter { get; set; }
    public int TimeInMiniGameSec { get; set; } 
    public bool IsMiniGameStarted { get; set; }

    public List<UserTask> UserTasks { get; set; }

    public int RewardDayCount { get; set; }
    public DateTimeOffset? RewardClaimedDate { get; set; }

    public Guid ReferralCodeId { get; set; } = Guid.NewGuid();

    public int MaxNumberOfInvites { get; set; } = 10;
}
