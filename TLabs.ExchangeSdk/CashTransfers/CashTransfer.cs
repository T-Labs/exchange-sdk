using System;
using System.ComponentModel.DataAnnotations;
using TLabs.ExchangeSdk.Depository;

namespace TLabs.ExchangeSdk.CashTransfers
{
    /// <summary>Request for cash deposit or cash withdrawal</summary>
    public class CashTransfer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PublicId { get; set; }

        /// <summary>true - Deposit, false - Withdrawal</summary>
        public bool IsDeposit { get; set; }

        public CashTransferStatus Status { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }
        public decimal AmountAfterCommission { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }

        public bool IsCanceled => Status == CashTransferStatus.CanceledByUser
            || Status == CashTransferStatus.CanceledByAdmin
            || Status == CashTransferStatus.AutoCanceled;

        public override string ToString() => $"{nameof(CashTransfer)}{(IsDeposit ? "Deposit" : "Withdrawal")}" +
            $"({Status}, {Amount} {CurrencyCode}, Id:{Id}, user:{UserId}, {DateCreated})";
    }

    public enum CashTransferStatus
    {
        Created = 0, InProcess = 10, Completed = 20,
        CanceledByUser = 100, CanceledByAdmin = 110, AutoCanceled = 120,
    }
}
