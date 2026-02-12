namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingDirectReferralDto
    {
        public string UserId { get; set; }
        public string CurrentLevel { get; set; }
        public decimal ReferralsStakingTokens { get; set; }
        public decimal PersonalStakingTokens { get; set; }
        public decimal PersonalStakingUsdt { get; set; }
    }
}
