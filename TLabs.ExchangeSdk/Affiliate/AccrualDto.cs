using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class AccrualDto
    {
        public DateTimeOffset Date { get; set; }

        public ProfitType ProfitType { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }
    }
}
