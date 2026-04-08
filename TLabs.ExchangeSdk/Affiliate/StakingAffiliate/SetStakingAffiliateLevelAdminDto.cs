namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class SetStakingAffiliateLevelAdminDto
    {
        /// <summary>Staking affiliate level name, e.g. R0, R1, None</summary>
        public string Level { get; set; }

        /// <summary>Days to keep automatic recalculation from changing level; 0 clears freeze.</summary>
        public int FreezeDays { get; set; }
    }
}
