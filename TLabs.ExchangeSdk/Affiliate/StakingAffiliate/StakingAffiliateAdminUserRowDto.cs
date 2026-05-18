using System;

namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingAffiliateAdminUserRowDto
    {
        public string UserId { get; set; }
        public string PublicId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string CurrentLevel { get; set; }
        public DateTimeOffset? LevelRecalculationFrozenUntil { get; set; }
        public int? RemainingFreezeDays { get; set; }
    }
}
