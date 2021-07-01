using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.Exchanges
{
    public enum ExchangeStatus
    {
        Started = 0, DepositoryBlocked = 10, AwaitingApproval = 20, Approved = 30,
        OrderCreated = 40, OrderCompleted = 50,
        SuccessFinished = 60, ErrorFinished = 70,
    };

    public class ExchangeOrder : OrderBase
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public DateTimeOffset DateUpdated { get; set; }
        public DateTimeOffset? DateApproved { get; set; }
        public DateTimeOffset? DateOrderPlaced { get; set; }
        public DateTimeOffset? DateOrderFinished { get; set; }

        public ExchangeStatus Status { get; set; }
        public Guid? OrderId { get; set; }
        public decimal Fulfilled { get; set; }

        public string ErrorText { get; set; }
        public string Comment { get; set; }

        public override string ToString() => $"{nameof(ExchangeOrder)}({Id} {Status}, " +
            $"{CurrencyPairCode} {(IsBid ? "bid" : "ask")}, created:{DateCreated}, user:{UserId}, " +
            $"price:{Price}, filled:{Fulfilled}/{Amount})";
    }
}
