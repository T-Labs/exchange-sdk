using System;
using System.ComponentModel.DataAnnotations;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.ExternalPayments
{
    public class ExternalPaymentFile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public string AdminUserId { get; set; }

        public byte[] Data { get; set; }

        public override string ToString() => $"{nameof(ExternalPaymentFile)}({Id}, UserId:{UserId}," +
            $" DataSize:{Data?.Length ?? 0})";
    }
}
