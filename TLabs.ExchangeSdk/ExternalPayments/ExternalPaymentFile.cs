using System;
using System.ComponentModel.DataAnnotations;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.ExternalPayments
{
    public class ExternalPaymentFile
    {
        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        [Required]
        public string UserId { get; set; }

        public string AdminUserId { get; set; }

        [Required]
        public string FileExtension { get; set; }

        public byte[] Data { get; set; }
        
        public string FileName => $"payment_file_{Id.ToString().Substring(0, 6)}.{FileExtension}";

        public override string ToString() => $"{nameof(ExternalPaymentFile)}({Id} {FileExtension}, UserId:{UserId}," +
            $" DataSize:{Data?.Length ?? 0})";
    }
}
