using System;

namespace TLabs.ExchangeSdk.Trading
{
    /// <summary>Simplified record of deal, stored in MarketData</summary>
    public class MarketdataDeal
    {
        /// <summary>Deal guid</summary>
        public Guid DealId { get; set; }

        /// <summary>Date deal created</summary>
        public DateTime DealDateUtc { get; set; }

        /// <summary>Deal volume in base currency</summary>
        public decimal Volume { get; set; }

        /// <summary>Deal price</summary>
        public decimal Price { get; set; }

        /// <summary>Currency pair code</summary>
        public string CurrencyPairId { get; set; }

        /// <summary>Bid guid</summary>
        public Guid BidId { get; set; }

        /// <summary>Ask guid</summary>
        public Guid AskId { get; set; }

        /// <summary>UserId that created bid</summary>
        public string UserBidId { get; set; }

        /// <summary>UserId that created ask</summary>
        public string UserAskId { get; set; }

        /// <summary>Is created by inner trading bot</summary>
        public bool FromInnerTradingBot { get; set; } = false;

        /// <summary>Buy or Sell type</summary>
        public bool IsBuy { get; set; }
    }
}
