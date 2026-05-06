using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Commissions
{
    public class CommissionsInfo
    {
        public List<Commission> Commissions { get; set; } = new List<Commission>();

        /// <summary>User has flag to not pay any trade commissions</summary>
        public bool UserNoTradeCommissions { get; set; }

        /// <summary>Per-user trading commission discount fraction for DealBid (0..1); payable amount *= (1 - fraction).</summary>
        public decimal DealBidDiscountFraction { get; set; }

        /// <summary>Per-user trading commission discount fraction for DealAsk (0..1).</summary>
        public decimal DealAskDiscountFraction { get; set; }
    }
}
