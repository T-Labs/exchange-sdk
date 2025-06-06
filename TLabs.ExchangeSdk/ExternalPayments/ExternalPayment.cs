using System;
using System.ComponentModel.DataAnnotations;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.ExternalPayments
{
    public class ExternalPayment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public string AdminUserId { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        [Required]
        public string Status { get; set; }

        public string Description { get; set; }

        public override string ToString() => $"{nameof(ExternalPayment)}({Id}, UserId:{UserId}, Status:{Status}, " +
            $"DateAdded:{DateAdded})";

        public void Trim()
        {
            Status = Status?.Trim().NullIfEmpty();
            Description = Description?.Trim().NullIfEmpty();
        }
    }
}
