using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class Order : OrderBase
    {
        public Order()
        {
        }

        public Order(bool isBid, string currencyPairCode, decimal price, decimal amount)
        {
            IsBid = isBid;
            CurrencyPairCode = currencyPairCode;
            Price = price;
            Amount = amount;
        }

        public Guid Id { get; set; }

        public ClientType ClientType { get; set; }

        [Required]
        public string UserId { get; set; }

        /// <summary>Executed amount</summary>
        public decimal Fulfilled { get; set; }

        /// <summary>Amount that is being processed by LiquidityImport</summary>
        public decimal Blocked { get; set; }

        public bool IsCanceled { get; set; }

        /// <summary>Original order exchange</summary>
        public Exchange Exchange { get; set; } = Exchange.Local;

        public decimal AvailableAmount => Amount - Fulfilled - Blocked;

        public bool IsActive => !IsCanceled && Fulfilled < Amount;

        public bool IsLocal => Exchange == Exchange.Local;

        public string Status => (Fulfilled == 0 && !IsCanceled) ? "Created"
            : (Fulfilled == Amount) ? "Completed"
            : (Fulfilled > 0 && !IsCanceled) ? "PartiallyCompleted"
            : (Fulfilled == 0 && IsCanceled) ? "Canceled"
            : (Amount > 0 && IsCanceled) ? "PartiallyExecutedAndCanceled"
            : "Default";

        public bool HasSameTradingBotFlag(Order order2)
        {
            bool isOrder1FromDealsBot = this.ClientType == ClientType.DealsBot;
            bool isOrder2FromDealsBot = order2.ClientType == ClientType.DealsBot;
            return isOrder1FromDealsBot == isOrder2FromDealsBot;
        }

        public override string ToString() => $"{nameof(Order)}{(IsBid ? "Bid" : "Ask")}({Id} {CurrencyPairCode} " +
            $"created:{DateCreated} {Status} {(IsCanceled ? "canceled" : "")}, {ClientType} {UserId}, {Exchange} " +
            $"Available:{AvailableAmount} filled:{Fulfilled}+{Blocked}/{Amount} for price:{Price})";

        public Order Clone() => (Order)MemberwiseClone();
    }
}
