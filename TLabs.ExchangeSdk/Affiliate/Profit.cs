using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Affiliate
{
    /// <summary>profit</summary>
    public class Profit
    {
        public Guid MessageId { get; set; }

        /// <summary>User who made profit for referrers</summary>
        public string UserId { get; set; }

        public ProfitType ProfitType { get; set; }

        /// <summary>Profit amount in initial currency</summary>
        public decimal Amount { get; set; }

        /// <summary>Profit currency</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Total percentage of Profit amount that went to referrers</summary>
        public decimal? PercentageToUsers { get; set; }

        public DateTimeOffset ProfitDate { get; set; }

        public override string ToString() =>
            $"{nameof(Profit)}({MessageId} {ProfitType}, {Amount} {CurrencyCode}, {PercentageToUsers}% to users, {ProfitDate})";
    }
}
