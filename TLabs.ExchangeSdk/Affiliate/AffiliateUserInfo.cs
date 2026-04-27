using System.Collections.Generic;
using System.Linq;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class AffiliateUserInfo
    {
        public string InviteCode { get; set; }

        /// <summary>Referrer user id (not null if user registered by referral link)</summary>
        public string ParentUserId { get; set; }

        /// <summary>
        /// Info of referrals on each level
        /// </summary>
        public List<StandardReferralsLevelInfo> ReferralsLevelInfos { get; set; } = new();

        public bool IsAmbassador { get; set; }

        /// <summary>Ambassador level 2 percentage in decimal form (e.g. 0.2 = 20%)</summary>
        public decimal AmbassadorSecondLevelPercent { get; set; }

        /// <summary>
        /// Trading fee discount in decimal form (e.g. 0.4 = 40%) applied to user
        /// when they registered using ambassador link.
        /// </summary>
        public decimal CommissionDiscountPercent { get; set; }

        public decimal TotalProfitAmount =>
            ReferralsLevelInfos?.Select(_ => _.ProfitAmount).DefaultIfEmpty(0).Sum() ?? 0;
    }
}
