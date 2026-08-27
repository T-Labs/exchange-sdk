namespace TLabs.ExchangeSdk.DevelopersSalary
{
    /// <summary>Per-currency summary of the developers salary wallet.</summary>
    public class DevelopersSalarySummaryItem
    {
        public string CurrencyCode { get; set; }

        /// <summary>Current wallet balance in depository (accrued minus paid out).</summary>
        public decimal Balance { get; set; }

        public decimal TotalAccrued { get; set; }

        public decimal TotalPaidOut { get; set; }
    }
}
