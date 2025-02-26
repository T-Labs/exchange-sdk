using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class ReferralsLevelInfo
    {
        public int Level { get; set; }

        /// <summary>
        /// Depends on user's tariff
        /// </summary>
        public bool IsActive { get; set; }

        public decimal ProfitAmount { get; set; }

        public int ReferralsTotalCount { get; set; }
        public int ReferralsBusinessCount { get; set; }
        public int ReferralsPremiumCount { get; set; }
    }
}
