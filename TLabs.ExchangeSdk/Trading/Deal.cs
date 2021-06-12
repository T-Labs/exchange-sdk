using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class Deal
    {
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

        public override string ToString() => $"Deal({DealId}, {DateCreated}, Volume:{Volume}, " +
            $"{(IsSentToDealEnding ? "" : "Not processed")}, " +
            $"\n{Bid?.ToString() ?? BidId.ToString()} ,\n{Ask?.ToString() ?? AskId.ToString()} )";
    }
}
