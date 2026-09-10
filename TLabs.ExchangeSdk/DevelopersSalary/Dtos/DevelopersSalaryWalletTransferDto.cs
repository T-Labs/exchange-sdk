using System;

namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>On-chain transfer of an accrued share from the hot wallet to the fund address.</summary>
    public class DevelopersSalaryWalletTransferDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset? DateTimeCreated { get; set; }

        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public decimal Amount { get; set; }

        public string StatusId { get; set; }

        public string Address { get; set; }

        public string TxId { get; set; }

        public string ErrorText { get; set; }

        /// <summary>Ledger entry of the transfer is saved.</summary>
        public bool IsLedgerSaved { get; set; }

        public override string ToString() =>
            $"{nameof(DevelopersSalaryWalletTransferDto)}(Id:{Id}, {StatusId}, {Amount} {CurrencyCode} via {AdapterCode})";
    }
}
