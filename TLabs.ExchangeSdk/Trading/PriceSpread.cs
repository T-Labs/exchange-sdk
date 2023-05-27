using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class PriceSpread
    {
        public string CurrencyPair { get; set; }
        public decimal BidMax { get; set; }
        public decimal AskMin { get; set; }
    }
}
