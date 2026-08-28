using System;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>External crypto address of a developer for a currency.</summary>
    public class DeveloperAddressDto
    {
        public Guid Id { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public override string ToString() =>
            $"{nameof(DeveloperAddressDto)}(Id:{Id}, {CurrencyCode} ({AdapterCode}), {Address})";
    }
}
