using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.Farming;

public class User
{
    [Key]
    public long Id { get; set; }

    public long TenantId { get; set; }

    public string UserName { get; set; }

    public string? TgUserName { get; set; }
    public long TgUserId { get; set; }

    public string? AvatarImageId { get; set; }

    public DateTimeOffset DateRegistered { get; set; }
    public DateTimeOffset? DateFarmingStarted { get; set; }

    public List<UserTask> UserTasks { get; set; }

    public int RewardDayCount { get; set; }
    public DateTimeOffset? RewardClaimedDate { get; set; }

    public Guid ReferralCodeId { get; set; } = Guid.NewGuid();
    public int? MaxNumberOfInvites { get; set; }

    public List<Transaction> Transactions { get; set; }

    public string? CountryCode { get; set; }
    public string? LangCode { get; set; }
    public Region Region { get; set; }

    [NotMapped]
    public decimal Balance { get; set; }
}

public enum Region
{
    Undefined = 0,
    CIS = 10,
    Europe = 20,
    Africa = 30,
    Asia = 40,
}
