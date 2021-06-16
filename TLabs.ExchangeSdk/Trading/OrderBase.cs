using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Trading
{
    public class OrderBase
    {
        public OrderBase()
        {
        }

        public OrderBase(bool isBid, string currencyPairCode, decimal price, decimal amount)
        {
            IsBid = isBid;
            CurrencyPairCode = currencyPairCode;
            Price = price;
            Amount = amount;
        }

        [Required]
        public string CurrencyPairCode { get; set; }

        public bool IsBid { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        public bool HasSameOrderbookSide(Order order2) => this.IsBid == order2.IsBid;

        public bool HasSameCurrencyPair(Order order2) => this.CurrencyPairCode == order2.CurrencyPairCode;

        public override string ToString() => $"{nameof(OrderBase)}({(IsBid ? "bid" : "ask")} amount:{Amount} price:{Price})";

        public OrderBase Clone() => (OrderBase)MemberwiseClone();
    }
}
