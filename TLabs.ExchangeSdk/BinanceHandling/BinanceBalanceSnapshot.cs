using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.BinanceHandling
{
    public class BinanceBalanceSnapshot
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateOfSnapshot { get; set; }
        public Guid BinanceHandlingAccountId { get; set; }
        public BinanceHandlingAccount BinanceHandlingAccount { get; set; }

        /// <summary>Sum of all balances (free and locked) in BTC equivalent</summary>
        public decimal TotalBtc { get; set; }

        /// <summary>Sum of all balances (free and locked) in ETH equivalent</summary>
        public decimal TotalEth { get; set; }

        /// <summary>Sum of all balances (free and locked) in USDT equivalent</summary>
        public decimal TotalUsdt { get; set; }

        public decimal BtcBalance { get; set; }
        public decimal EthBalance { get; set; }
        public decimal UsdtBalance { get; set; }

        public string AllBalancesJson { get; set; }
        public string TotalBalanceSkippedCurrencies { get; set; }
    }
}
