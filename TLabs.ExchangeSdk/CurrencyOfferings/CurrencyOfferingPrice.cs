using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.CurrencyOfferings
{
    public class CurrencyOfferingPrice
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>CurrencyOffering Code</summary>
        public string CurrencyCode { get; set; }

        public string PayingCurrencyCode { get; set; }

        public decimal Price { get; set; }

        public override string ToString() => $"{nameof(CurrencyOfferingPrice)}({CurrencyCode} for {PayingCurrencyCode}, Price:{Price})";
    }
}
