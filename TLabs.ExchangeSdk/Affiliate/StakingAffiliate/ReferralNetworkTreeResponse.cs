using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    /// <summary>Response of the referral network-tree endpoint (flat list of nodes; edges via ParentUserId).</summary>
    public class ReferralNetworkTreeResponse
    {
        public List<ReferralNetworkNodeDto> Nodes { get; set; } = new List<ReferralNetworkNodeDto>();
    }
}
