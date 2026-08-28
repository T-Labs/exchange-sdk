using System;

using TLabs.ExchangeSdk.DevelopersSalary.Enums;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>
    /// Accrual of a percent of a large user crypto deposit to the developers salary wallet.
    /// Paid by the exchange (Funds -> FundDevelopersSalary), the user keeps the full deposit.
    /// </summary>
    public class DevelopersSalaryAccrualDto
    {
        public Guid Id { get; set; }

        /// <summary>Blockchain tx hash of the source deposit.</summary>
        public string DepositTxId { get; set; }

        public string UserId { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        /// <summary>Full deposit amount in deposit currency.</summary>
        public decimal DepositAmount { get; set; }

        public decimal PercentApplied { get; set; }

        /// <summary>Accrued amount in deposit currency.</summary>
        public decimal Amount { get; set; }

        public DevelopersSalaryAccrualStatus Status { get; set; }

        public string ErrorText { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public override string ToString() =>
            $"{nameof(DevelopersSalaryAccrualDto)}(Id:{Id}, {Status}, {Amount} {CurrencyCode} from deposit {DepositAmount}, " +
            $"user:{UserId}, txId:{DepositTxId})";
    }
}
