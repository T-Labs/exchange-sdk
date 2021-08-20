using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class MatchingOrder : Order
    {
        public MatchingOrder()
        {
        }

        public MatchingOrder(bool isBid, string currencyPairCode, decimal price, decimal amount)
            : base(isBid, currencyPairCode, price, amount)
        {
        }

        public virtual List<MatchingDeal> DealList { get; set; }

        public MatchingOrder Clone() => (MatchingOrder)MemberwiseClone();
    }
}
