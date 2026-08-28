namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>Settings of accruals to the developers salary wallet.</summary>
    public class DevelopersSalarySettingsDto
    {
        /// <summary>Accruals are disabled until an admin turns them on (after all modules are deployed).</summary>
        public bool Enabled { get; set; }

        /// <summary>The only currency the wallet works with (accruals and payouts). No rate conversions.</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Allowed network adapter codes, comma-separated (e.g. "trx,bsc").</summary>
        public string AdapterCodes { get; set; }

        /// <summary>Deposits (in <see cref="CurrencyCode"/>) above this threshold trigger an accrual.</summary>
        public decimal UsdThreshold { get; set; }

        /// <summary>Percent of the full deposit amount sent to the wallet.</summary>
        public decimal PercentToSend { get; set; }

        public override string ToString() =>
            $"{nameof(DevelopersSalarySettingsDto)}(Enabled:{Enabled}, {CurrencyCode} via [{AdapterCodes}], " +
            $"Threshold:{UsdThreshold}$, Percent:{PercentToSend})";
    }
}
