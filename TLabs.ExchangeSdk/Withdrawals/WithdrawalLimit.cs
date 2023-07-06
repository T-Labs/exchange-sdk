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
    }
}
