using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class Reward
{
    [Key]
    public long Id { get; set; }

    public RewardType RewardType { get; set; }
    public decimal AmountReward { get; set; }
    public long TenantId { get; set; }
    public List<ActionTask> ActionTask { get; set; }
}

public enum RewardType
{
    day = 200,
    farming = 300,
    firstLevelReferral = 400,
    secondLevelReferral = 500,
}
