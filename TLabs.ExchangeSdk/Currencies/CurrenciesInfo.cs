using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Currencies
{
    public class CurrenciesInfo
    {
        public List<Currency> Currencies { get; set; }
        public List<CurrencyPair> CurrencyPairs { get; set; }
        public List<Adapter> Adapters { get; set; }
    }
}
