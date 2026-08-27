namespace TLabs.ExchangeSdk.DevelopersSalary
{
    /// <summary>Settings of accruals to the developers salary wallet. Single row, stored in stock-withdrawals.</summary>
    public class DevelopersSalarySettings
    {
        public int Id { get; set; } = 1;

        /// <summary>Accruals are disabled until an admin turns them on (after all modules are deployed).</summary>
        public bool Enabled { get; set; }

        /// <summary>Deposits with USD(T) value above this threshold trigger an accrual.</summary>
        public decimal UsdThreshold { get; set; } = 1000;

        /// <summary>Percent of the full deposit amount sent to the wallet.</summary>
        public decimal PercentToSend { get; set; } = 10;

        public override string ToString() =>
            $"{nameof(DevelopersSalarySettings)}(Enabled:{Enabled}, Threshold:{UsdThreshold}$, Percent:{PercentToSend})";
    }
}
