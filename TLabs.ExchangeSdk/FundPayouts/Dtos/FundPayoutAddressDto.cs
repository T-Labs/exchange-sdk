using System;

namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    public class FundPayoutAddressDto
    {
        public Guid Id { get; set; }

        public string FundCode { get; set; }

        /// <summary>Recipient userId, or the fund code for a technical address without a user.</summary>
        public string UserId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
