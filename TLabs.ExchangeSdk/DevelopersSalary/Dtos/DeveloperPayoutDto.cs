using System;

using TLabs.ExchangeSdk.DevelopersSalary.Enums;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>On-chain payout from the developers salary wallet to a developer address.</summary>
    public class DeveloperPayoutDto
    {
        public Guid Id { get; set; }

        public Guid DeveloperId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }

        public string TxId { get; set; }

        public DeveloperPayoutStatus Status { get; set; }

        /// <summary>Depository transaction (DevelopersSalaryPayout) is saved; retried by BgService if false after send.</summary>
        public bool IsLedgerSaved { get; set; }

        /// <summary>Admin who created the payout.</summary>
        public string CreatedByUserId { get; set; }

        public string ErrorText { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public override string ToString() =>
            $"{nameof(DeveloperPayoutDto)}(Id:{Id}, {Status}, {Amount} {CurrencyCode} ({AdapterCode}), " +
            $"developer:{DeveloperId}, {Address}, txId:{TxId})";
    }
}
