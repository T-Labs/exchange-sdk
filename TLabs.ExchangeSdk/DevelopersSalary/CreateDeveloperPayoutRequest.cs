using System;

namespace TLabs.ExchangeSdk.DevelopersSalary
{
    public class CreateDeveloperPayoutRequest
    {
        public Guid DeveloperId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }

        public string CreatedByUserId { get; set; }

        public override string ToString() =>
            $"{nameof(CreateDeveloperPayoutRequest)}(developer:{DeveloperId}, {Amount} {CurrencyCode} ({AdapterCode}), " +
            $"{Address}, by:{CreatedByUserId})";
    }
}
