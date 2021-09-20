using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.LiquidityImport
{
    public class BalanceSnapshotDto
    {
        public DateTimeOffset Date { get; set; }
        public decimal TotalBtc { get; set; }
        public Dictionary<string, decimal> Balances { get; set; } = new();
        public Dictionary<string, decimal> BalancesLocked { get; set; } = new();

        public decimal GetCurrencyTotalBalance(string currencyCode) =>
            Balances.GetValueOrDefault(currencyCode, 0) + BalancesLocked.GetValueOrDefault(currencyCode, 0);
    }
}
