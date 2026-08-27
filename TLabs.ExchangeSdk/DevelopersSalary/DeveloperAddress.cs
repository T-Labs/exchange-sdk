using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.DevelopersSalary
{
    /// <summary>External crypto address of a developer for a currency.</summary>
    public class DeveloperAddress
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DeveloperId { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        [Required]
        public string Address { get; set; }

        public string Memo { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public override string ToString() =>
            $"{nameof(DeveloperAddress)}(Id:{Id}, developer:{DeveloperId}, {CurrencyCode} ({AdapterCode}), {Address})";
    }
}
