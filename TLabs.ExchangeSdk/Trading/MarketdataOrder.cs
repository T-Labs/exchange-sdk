using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class MarketdataOrder : Order
    {
        public MarketdataOrder()
        {
        }

        public MarketdataOrder(bool isBid, string currencyPairCode, decimal price, decimal amount)
            : base(isBid, currencyPairCode, price, amount)
        {
        }

        public virtual List<MarketdataDeal> Deals { get; set; }

        public MatchingOrder Clone() => (MatchingOrder)MemberwiseClone();
    }
}
