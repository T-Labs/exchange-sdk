using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class OrderCreateRequest
    {
        /// <summary>Becomes order Id in matching-engine</summary>
        public string ActionId { get; set; }

        public bool IsBid { get; set; }
        public string CurrencyPairCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public ClientType ClientType { get; set; }
        public string UserId { get; set; }

        public override string ToString() => $"{nameof(OrderCreateRequest)}({(IsBid ? "Bid" : "Ask")} " +
            $"{CurrencyPairCode}, Amount:{Amount}, Price:{Price}, {ClientType} {UserId}, ActionId: {ActionId})";
    }
}
