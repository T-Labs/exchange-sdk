namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingAffiliateUserDto
    {
        public string CurrentLevel { get; set; }
        public int TotalDescendantsCount { get; set; }
        public int ActiveStakersCount { get; set; }

        /// <summary>Own active stakes: total locked BINI (nominal token amount from affiliate metrics).</summary>
        public decimal PersonalStakingTokens { get; set; }

        /// <summary>Own active stakes: USDT equivalent at the rate last written into affiliate metrics (level thresholds / display; not the historical open price).</summary>
        public decimal PersonalStakingUsdt { get; set; }

        /// <summary>Entire referral tree: total BINI in active stakes (aggregated in affiliate metrics).</summary>
        public decimal ReferralsStakingTokens { get; set; }

        /// <summary>Entire referral tree: USDT equivalent of team BINI at current pricing when populated; may be 0 until filled by API/gateway/UI.</summary>
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
