using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class AmbassadorSettingsDto
    {
        public bool IsAmbassador { get; set; }

        /// <summary>Percent in human-readable form (0..20)</summary>
        public decimal SecondLevelPercent { get; set; }
    }

    public class AmbassadorReferralLinkDto
    {
        public Guid Id { get; set; }
        public string OwnerUserId { get; set; }
        public string Code { get; set; }

        /// <summary>Percent in human-readable form (1..50)</summary>
        public decimal DiscountPercent { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateAmbassadorReferralLinkRequest
    {
        /// <summary>Percent in human-readable form (1..50)</summary>
        public decimal DiscountPercent { get; set; }
    }
}
