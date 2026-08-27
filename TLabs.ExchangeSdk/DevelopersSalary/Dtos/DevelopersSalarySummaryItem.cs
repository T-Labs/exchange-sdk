using System.Collections.Generic;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>Per-currency summary of the developers salary wallet.</summary>
    public class DevelopersSalarySummaryItem
    {
        public string CurrencyCode { get; set; }

        /// <summary>Current wallet balance in depository (accrued minus paid out).</summary>
        public decimal Balance { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalPaidOut { get; set; }

        /// <summary>On-chain balance of each network's hot wallet (adapterCode -> amount) —
        /// the real limit for a payout through that network right now.</summary>
        public Dictionary<string, decimal> HotWalletBalances { get; set; } = new();
    }
}
