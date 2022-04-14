using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Depository
{
    public class TurnoversDto
    {
        public string UserId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Deposited { get; set; }
        public decimal Withdrawn { get; set; }
        public decimal Nullified { get; set; }
        public decimal TradeBuy { get; set; }
        public decimal TradeSell { get; set; }
        public decimal TradeDiff { get; set; }
        public decimal PaidFees { get; set; }

        public override string ToString() => $"{nameof(TurnoversDto)}({CurrencyCode}, " +
            $"Deposited {Deposited}, Withdrawn {Withdrawn}, user:{UserId})";
    }
}
