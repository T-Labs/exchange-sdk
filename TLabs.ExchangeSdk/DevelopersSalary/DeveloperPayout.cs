using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.DevelopersSalary
{
    /// <summary>
    /// On-chain payout from the developers salary wallet to a developer address.
    /// Id is used as ActionId of the depository transaction, the actual send reuses the Withdrawals pipeline.
    /// </summary>
    public class DeveloperPayout
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DeveloperId { get; set; }

        /// <summary>Linked row in Withdrawals table that performs the on-chain send.</summary>
        public Guid? WithdrawalId { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        [Required]
        public string Address { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }

        public string TxId { get; set; }

        public DeveloperPayoutStatus Status { get; set; } = DeveloperPayoutStatus.Created;

        /// <summary>Depository transaction (DevelopersSalaryPayout) is saved; retried by BgService if false after send.</summary>
        public bool IsLedgerSaved { get; set; }

        /// <summary>Admin who created the payout.</summary>
        public string CreatedByUserId { get; set; }

        public string ErrorText { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? ConfirmedAt { get; set; }

        public override string ToString() =>
            $"{nameof(DeveloperPayout)}(Id:{Id}, {Status}, {Amount} {CurrencyCode} ({AdapterCode}), " +
            $"developer:{DeveloperId}, {Address}, txId:{TxId})";
    }

    public enum DeveloperPayoutStatus
    {
        Created = 10,
        Sent = 20,
        Confirmed = 30,
        Error = 40,
    }
}
