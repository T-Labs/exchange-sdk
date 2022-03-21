using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Currencies
{
    public class CurrencyAdapter
    {
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }
        public string TokenAddress { get; set; }

        public override string ToString() =>
            $"{nameof(CurrencyAdapter)}({CurrencyCode} - {AdapterCode}, Address:{TokenAddress})";
    }
}
