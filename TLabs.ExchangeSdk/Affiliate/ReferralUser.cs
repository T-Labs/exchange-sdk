using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class ReferralUser
    {
        [Key]
        public string UserId { get; set; }

        /// <summary>
        /// Referrer user id (not null if user registered by referral link)
        /// </summary>
        public string ParentUserId { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        /// <summary>User's country code</summary>
        public string CountryCode { get; set; }

        /// <summary>Code this user can use to invite other people</summary>
        public string UserInviteCode { get; set; }

        /// <summary>Ambassador flag configured from admin</summary>
        public bool IsAmbassador { get; set; }

        /// <summary>Ambassador level 2 percentage in decimal form (e.g. 0.2 = 20%)</summary>
        public decimal AmbassadorSecondLevelPercent { get; set; }

        /// <summary>
        /// Trading fee discount in decimal form (e.g. 0.4 = 40%) applied to this user
        /// when registered via ambassador link.
        /// </summary>
        public decimal CommissionDiscountPercent { get; set; }
    }
}
