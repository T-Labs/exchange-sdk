using System;

namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    /// <summary>Projection of a Withdrawal row with FundPayoutCode set.</summary>
    public class FundPayoutDto
    {
        public Guid Id { get; set; }

        public string FundCode { get; set; }

        public string UserId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }

        public string TxId { get; set; }

        /// <summary>WithdrawalStatus.Code</summary>
        public int StatusId { get; set; }

        public string ErrorText { get; set; }

        public string ClientIdempotencyKey { get; set; }

        public DateTimeOffset? DateTimeCreated { get; set; }

        public DateTimeOffset? DateTimeProcessed { get; set; }

        public override string ToString() =>
            $"{nameof(FundPayoutDto)}(Id:{Id}, {FundCode}, status:{StatusId}, {Amount} {CurrencyCode} ({AdapterCode}), " +
            $"user:{UserId}, {Address}, txId:{TxId})";
    }
}
