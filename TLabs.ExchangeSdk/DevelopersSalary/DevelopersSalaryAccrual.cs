using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.DevelopersSalary
{
    /// <summary>
    /// Accrual of a percent of a large user crypto deposit to the developers salary wallet.
    /// Paid by the exchange (Funds -> FundDevelopersSalary), the user keeps the full deposit.
    /// Id is used as ActionId of the depository transaction.
    /// </summary>
    public class DevelopersSalaryAccrual
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>Blockchain tx hash of the source deposit. Unique with UserId+CurrencyCode to prevent double accrual.</summary>
        [Required]
        public string DepositTxId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        /// <summary>Full deposit amount in deposit currency.</summary>
        public decimal DepositAmount { get; set; }

        /// <summary>UsdtRate quote at the moment of the deposit.</summary>
        public decimal UsdtRate { get; set; }

        /// <summary>Estimated deposit value in USDT.</summary>
        public decimal UsdValue { get; set; }

        /// <summary>Snapshot of settings applied to this accrual.</summary>
        public decimal UsdThresholdApplied { get; set; }

        public decimal PercentApplied { get; set; }

        /// <summary>Accrued amount in deposit currency.</summary>
        public decimal Amount { get; set; }

        public DevelopersSalaryAccrualStatus Status { get; set; } = DevelopersSalaryAccrualStatus.Created;

        public string ErrorText { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? CompletedAt { get; set; }

        public override string ToString() =>
            $"{nameof(DevelopersSalaryAccrual)}(Id:{Id}, {Status}, {Amount} {CurrencyCode} from deposit {DepositAmount} " +
            $"(~{UsdValue}$), user:{UserId}, txId:{DepositTxId})";
    }

    public enum DevelopersSalaryAccrualStatus
    {
        Created = 10,
        Completed = 20,
        Error = 30,
    }
}
