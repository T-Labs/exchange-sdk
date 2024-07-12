using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class Reward
{
    [Key]
    public long Id { get; set; }

    public decimal BaseReward { get; set; }
    public decimal IncrementPerDay { get; set; }
    public int MaxDays { get; set; }
    public RewardType RewardType { get; set; }
    public decimal AmountReward { get; set; }
    public long TenantId { get; set; }
    public List<ActionTask> ActionTask { get; set; }
}

public enum RewardType
{
    DailyLogin = 200,
    Farming = 300,
    FirstLevelReferral = 400,
    SecondLevelReferral = 500,
    ThirdLevelReferral = 600,
    ReferralSignUpBonus = 700,
    MiniGame = 800,
}
