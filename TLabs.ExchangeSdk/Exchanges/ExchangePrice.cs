using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Exchanges
{
    public class ExchangePrice
    {
        public Guid Id { get; set; }
        public string CurrencyPairCode { get; set; }
        public bool IsBid { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset DateExpire { get; set; }
    }
}
