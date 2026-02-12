namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingAffiliateUserDto
    {
        public string CurrentLevel { get; set; }
        public int TotalDescendantsCount { get; set; }
        public decimal PersonalStakingTokens { get; set; }
        public decimal PersonalStakingUsdt { get; set; }
        public decimal ReferralsStakingTokens { get; set; }
        public decimal MissingReferralsStakingTokens { get; set; }
    }
}
