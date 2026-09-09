namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    public class CreateFundPayoutRequest
    {
        public string FundCode { get; set; }

        /// <summary>Optional. When set, the address must be registered for this user; when empty, a registered
        /// address resolves its owner, an unregistered one is a one-time address (fund must allow it).</summary>
        public string UserId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }

        /// <summary>Optional globally unique key (max 128). Repeat with the same key returns the existing payout.</summary>
        public string ClientIdempotencyKey { get; set; }

        public override string ToString() =>
            $"{nameof(CreateFundPayoutRequest)}({FundCode}, user:{UserId}, {Amount} {CurrencyCode} ({AdapterCode}), " +
            $"{Address}, key:{ClientIdempotencyKey})";
    }
}
