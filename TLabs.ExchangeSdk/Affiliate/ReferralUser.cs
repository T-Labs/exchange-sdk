using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class ReferralUser
    {
        [Key]
        public string UserId { get; set; }

        /// <summary>
        /// Refferer user id (not null if user registered by referral link)
        /// </summary>
        public string ParentUserId { get; set; }

        public TariffType TariffType { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        /// <summary>User's country code</summary>
        public string CountryCode { get; set; }

        /// <summary>Code this user can use to invite other people</summary>
        public string UserInviteCode { get; set; }

        public ReferralTariff Tariff { get; set; }
    }
}
