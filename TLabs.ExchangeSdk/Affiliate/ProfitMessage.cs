using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.ExchangeSdk.RabbitMq;

namespace TLabs.ExchangeSdk.Affiliate
{
    /// <summary>Message that indicates user's profit</summary>
    public class ProfitMessage : Message
    {
        /// <summary>
        /// Source of profit
        /// </summary>
        public ProfitType ProfitType { get; set; }

        /// <summary>
        /// User who made profit for referrers
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Amount on distribution
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Transaction currency
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// If true then Affiliate should create tx to FundAffiliateBonusesForDistribution
        /// </summary>
        public bool CreateDistributionTx { get; set; }
    }
}
