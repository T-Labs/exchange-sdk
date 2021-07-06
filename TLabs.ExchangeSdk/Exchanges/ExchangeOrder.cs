using System;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.Exchanges
{
    public enum ExchangeStatus
    {
        Started = 0, SuccessFinished = 100, ErrorFinished = 110,
    };

    public class ExchangeOrder : OrderBase
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public DateTimeOffset DateUpdated { get; set; }

        public ExchangeStatus Status { get; set; }

        public string ErrorText { get; set; }
        public string Comment { get; set; }

        public override string ToString() => $"{nameof(ExchangeOrder)}({Id} {Status}, " +
            $"{CurrencyPairCode} {(IsBid ? "bid" : "ask")}, price:{Price}, amount:{Amount} " +
            $"created:{DateCreated}, user:{UserId})";
    }
}
