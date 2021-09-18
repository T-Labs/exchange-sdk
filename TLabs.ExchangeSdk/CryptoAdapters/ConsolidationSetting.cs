using System;
using System.Linq;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class ConsolidationSetting
    {
        public string CurrencyCode { get; set; }
        public bool UseConsolidation { get; set; }
        public decimal ConsolidationMinAmount { get; set; }
    }
}
