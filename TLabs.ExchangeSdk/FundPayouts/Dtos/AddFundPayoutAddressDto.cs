namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    public class AddFundPayoutAddressDto
    {
        public string FundCode { get; set; }

        /// <summary>Recipient userId; empty = technical address of the fund (UserId becomes the fund code).</summary>
        public string UserId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public override string ToString() =>
            $"{nameof(AddFundPayoutAddressDto)}({FundCode}, user:{UserId}, {CurrencyCode} ({AdapterCode}) {Address})";
    }
}
