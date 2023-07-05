using System;
using System.ComponentModel.DataAnnotations;
using TLabs.ExchangeSdk.Depository;

namespace TLabs.ExchangeSdk.CashDeposits
{
    /// <summary>Request for cash deposit</summary>
    public class CashDeposit
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PublicId { get; set; }

        public CashDepositStatus Status { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }

        public bool IsCanceled => Status == CashDepositStatus.CanceledByUser
            || Status == CashDepositStatus.CanceledByAdmin
            || Status == CashDepositStatus.AutoCanceled;

        public override string ToString() => $"{nameof(CashDeposit)}" +
            $"({Status}, {Amount} {CurrencyCode}, Id:{Id}, user:{UserId}, {DateCreated})";
    }

    public enum CashDepositStatus
    {
        Created = 0, Completed = 50,
        CanceledByUser = 100, CanceledByAdmin = 110, AutoCanceled = 120,
    }
}
