namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingDirectReferralDto
    {
        public string UserId { get; set; }

        /// <summary>Human-facing UID (PublicId from userprofiles); filled by BFF enrichment.</summary>
        public string PublicId { get; set; }

        public string Nickname { get; set; }
        public string AvatarId { get; set; }
        public bool IsVip { get; set; }
        public string CurrentLevel { get; set; }
        public decimal ReferralsStakingTokens { get; set; }
        public decimal PersonalStakingTokens { get; set; }
        public decimal PersonalStakingUsdt { get; set; }
        public bool HasEverStaked { get; set; }
        public int? DirectReferralsCount { get; set; }
        public int? TotalDescendantsCount { get; set; }

        /// <summary>Referrer (inviter) user id; null when the referral has no inviter.</summary>
        public string ParentUserId { get; set; }

        /// <summary>Inviter's UID/nickname for the "invited under" display; filled by BFF enrichment.
        /// Resolved even when the inviter is not in the current depth slice.</summary>
        public string ParentPublicId { get; set; }
        public string ParentNickname { get; set; }
    }
}
