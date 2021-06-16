using System;

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

        public string CurrencyPairCode { get; set; }
        public bool IsBid { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        public bool IsOnSameOrderbookSide(Order order2) => this.IsBid == order2.IsBid;
        public bool IsSameCurrencyPair(Order order2) => this.CurrencyPairCode == order2.CurrencyPairCode;

        public override string ToString() => $"{nameof(OrderBase)}({(IsBid ? "bid" : "ask")} amount:{Amount} price:{Price})";

        public OrderBase Clone() => (OrderBase)MemberwiseClone();
    }
}
