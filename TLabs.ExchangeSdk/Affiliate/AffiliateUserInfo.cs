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

        public decimal TotalProfitAmount =>
            ReferralsLevelInfos?.Select(_ => _.ProfitAmount).DefaultIfEmpty(0).Sum() ?? 0;
    }
}
