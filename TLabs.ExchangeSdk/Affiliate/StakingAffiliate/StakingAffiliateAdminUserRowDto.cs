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

        /// <summary>The active freeze floor (null when there is no freeze). May be below or above <see cref="CurrentLevel"/>.</summary>
        public string FreezeLevel { get; set; }
        public DateTimeOffset? LevelFrozenUntil { get; set; }
        public int? RemainingFreezeDays { get; set; }
    }
}
