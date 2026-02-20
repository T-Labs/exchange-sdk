using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    /// <summary>Configuration for staking affiliate level requirements</summary>
    public class StakingAffiliateLevelConfig
    {
        [Key]
        public StakingAffiliateLevel Level { get; set; }

        /// <summary>Minimum own staking in USD equivalent</summary>
        public decimal MinOwnStakingUsdt { get; set; }

        /// <summary>Number of required referrals at RequiredReferralLevel</summary>
        public int RequiredReferralCount { get; set; }

        /// <summary>Minimum level of required referrals (must be in different branches)</summary>
        public StakingAffiliateLevel RequiredReferralLevel { get; set; }

        /// <summary>Minimum total staking of all referrals (any depth) in BINI tokens</summary>
        public decimal MinTotalReferralStakingTokens { get; set; }

        /// <summary>Reward percentage (0.20 = 20%)</summary>
        public decimal RewardPercentage { get; set; }

        /// <summary>Percentage of accrual reward that goes to bonus balance (rest goes to default user balance)</summary>
        public decimal PercentageToUserBonuses { get; set; }

        public override string ToString()
        {
            return $"Level={Level}, MinOwn={MinOwnStakingUsdt}, Refs={RequiredReferralCount}x{RequiredReferralLevel}, " +
                $"TotalRef={MinTotalReferralStakingTokens}, Reward={RewardPercentage:P0}";
        }
    }
}
