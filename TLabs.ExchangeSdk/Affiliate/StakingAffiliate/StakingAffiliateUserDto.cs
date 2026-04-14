namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingAffiliateUserDto
    {
        public string CurrentLevel { get; set; }
        public int TotalDescendantsCount { get; set; }
        public int ActiveStakersCount { get; set; }
        public decimal PersonalStakingTokens { get; set; }
        public decimal PersonalStakingUsdt { get; set; }
        public decimal ReferralsStakingTokens { get; set; }
        public decimal ReferralsStakingUsdt { get; set; }
        public decimal MissingReferralsStakingTokens { get; set; }
        public int DirectReferralsCount { get; set; }

        /// <summary>Target next rank (R0–R8), or null if already max.</summary>
        public string NextLevel { get; set; }

        public bool IsMaxLevel { get; set; }

        public decimal? NextMinOwnStakingUsdt { get; set; }
        public decimal MissingPersonalStakingUsdt { get; set; }

        public decimal? NextMinTotalReferralStakingTokens { get; set; }

        public int NextRequiredReferralCount { get; set; }
        public string NextRequiredReferralLevel { get; set; }

        public int QualifiedReferralBranchesCount { get; set; }
    }
}
