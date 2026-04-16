using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class WithdrawalLimit
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ModerationAmount { get; set; }
        public decimal MinAmount { get; set; }

        /// <summary>Max total external withdrawal per user per currency per UTC day; 0 = no limit.</summary>
        public decimal MaxUserDailyWithdrawal { get; set; }

        /// <summary>Max total external withdrawal for all users per currency per UTC day; 0 = no limit.</summary>
        public decimal MaxGlobalDailyWithdrawal { get; set; }
    }
}
