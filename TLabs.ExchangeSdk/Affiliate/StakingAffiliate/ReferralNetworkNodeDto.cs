namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    /// <summary>One node in the referral network diagram (current user's surroundings:
    /// own subtree, upline chain, and neighbouring "foreign" branches).</summary>
    public class ReferralNetworkNodeDto
    {
        public string UserId { get; set; }

        /// <summary>Inviter (parent) user id. Null for the topmost node / no inviter.</summary>
        public string ParentUserId { get; set; }

        /// <summary>True when the node belongs to a branch outside the current user's own subtree/upline.
        /// Foreign nodes are shown without details (privacy) — only "foreign branch".</summary>
        public bool IsForeignBranch { get; set; }

        /// <summary>Human-facing UID (PublicId from userprofiles); filled by BFF enrichment, only for non-foreign nodes.</summary>
        public string PublicId { get; set; }

        public string Nickname { get; set; }
        public string AvatarId { get; set; }
        public bool IsVip { get; set; }

        public string CurrentLevel { get; set; }
        public decimal ReferralsStakingTokens { get; set; }
        public decimal PersonalStakingTokens { get; set; }
        public decimal PersonalStakingUsdt { get; set; }
        public bool HasEverStaked { get; set; }
        public int DirectReferralsCount { get; set; }
        public int TotalDescendantsCount { get; set; }

        /// <summary>User's invite code from ReferralUsers (for sharing); not a full URL.</summary>
        public string InviteCode { get; set; }
    }
}
