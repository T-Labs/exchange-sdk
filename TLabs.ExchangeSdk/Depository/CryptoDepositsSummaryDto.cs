using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Depository
{
    public class CryptoDepositsSummaryDto
    {
        public List<CryptoDepositsSummaryRowDto> Rows { get; set; }

        /// <summary>Sum of row Count values only. No cross-currency amount total.</summary>
        public int TotalCount { get; set; }
    }

    public class CryptoDepositsSummaryRowDto
    {
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }
        public decimal Amount { get; set; }
        public int Count { get; set; }
    }
}
