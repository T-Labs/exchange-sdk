using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class MatchingDeal
    {
        public MatchingDeal()
        {
        }

        public MatchingDeal(Order order1, Order order2, decimal price, decimal volume)
        {
            var (bid, ask) = order1.IsBid ? (order1, order2) : (order2, order1);
            if (!bid.IsBid)
            {
                throw new Exception($"No bids passed to Deal(): {order1}, {order2}");
            }

            if (ask.IsBid)
            {
                throw new Exception($"No asks passed to Deal(): {order1}, {order2}");
            }

            DealId = Guid.NewGuid(); // DealId is used before saving Deal to DB
            DateCreated = DateTimeOffset.UtcNow;
            BidId = bid.Id;
            AskId = ask.Id;
            Price = price;
            Volume = volume;
            FromInnerTradingBot = bid.ClientType == ClientType.DealsBot;
            IsSentToDealEnding = FromInnerTradingBot ? true : false; // all deals except deals-bot deals have to be processed
        }

        /// <summary>Deal guid</summary>
        [Key]
        public Guid DealId { get; set; }

        /// <summary>Date deal created</summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>Deal volume in base currency</summary>
        public decimal Volume { get; set; }

        /// <summary>Deal price</summary>
        public decimal Price { get; set; }

        /// <summary>Is processed by DealEnding</summary>
        public bool IsSentToDealEnding { get; set; } = false;

        /// <summary>Is created by inner trading bot</summary>
        public bool FromInnerTradingBot { get; set; } = false;

        /// <summary>Ask guid</summary>
        public Guid AskId { get; set; }

        /// <summary>Ask</summary>
        public Order Ask { get; set; }

        /// <summary>Bid guid</summary>
        public Guid BidId { get; set; }

        /// <summary>Bid</summary>
        public Order Bid { get; set; }

        public DealResponse GetDealResponse()
        {
            return new DealResponse()
            {
                DealId = DealId,
                Price = Price,
                Volume = Volume,
                DealDateUtc = DateCreated.DateTime,
                CurrencyPairId = Ask.CurrencyPairCode,
                BidId = Bid.Id,
                AskId = Ask.Id,
                UserBidId = Bid.UserId,
                UserAskId = Ask.UserId,
                IsBuy = Bid.DateCreated > Ask.DateCreated,
                FromInnerTradingBot = FromInnerTradingBot
            };
        }

        public override string ToString() => $"{nameof(MatchingDeal)}({DealId}, {DateCreated}, Volume:{Volume}, " +
            $"{(IsSentToDealEnding ? "" : "Not processed")}, " +
            $"\n{Bid?.ToString() ?? BidId.ToString()} ,\n{Ask?.ToString() ?? AskId.ToString()} )";
    }
}
