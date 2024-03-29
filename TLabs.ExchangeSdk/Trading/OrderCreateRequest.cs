using System;

namespace TLabs.ExchangeSdk.Trading
{
    public class OrderCreateRequest
    {
        /// <summary>Becomes order Id in matching-engine</summary>
        public string ActionId { get; set; }

        public bool IsMarket { get; set; }
        public bool IsBid { get; set; }
        public string CurrencyPairCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ClientType ClientType { get; set; }
        public string UserId { get; set; }

        /// <summary>Local, unless order is from LiquidtyImport</summary>
        public Exchange Exchange { get; set; } = Exchange.Local;

        /// <summary>Amount that was blocked in Depository for a market bid</summary>
        public decimal MarketBidTotalBlocked { get; set; }

        public Order GetOrder()
        {
            return new Order
            {
                Id = Guid.Parse(ActionId),
                IsMarket = IsMarket,
                IsBid = IsBid,
                Price = Price,
                Amount = Amount,
                CurrencyPairCode = CurrencyPairCode,
                DateCreated = DateCreated,
                UserId = UserId,
                ClientType = ClientType,
                Exchange = Exchange,
                MarketBidTotalBlocked = MarketBidTotalBlocked,
            };
        }

        public override string ToString() => $"{nameof(OrderCreateRequest)}({(IsMarket ? "Market" : "")}{(IsBid ? "Bid" : "Ask")} " +
            $"{CurrencyPairCode}, Amount:{Amount}, Price:{Price}, {ClientType} {UserId}, ActionId: {ActionId})";
    }
}
