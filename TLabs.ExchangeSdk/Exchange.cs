using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk
{
    public enum Exchange
    {
        Local = 0, Binance = 1, Okex = 2, Kraken = 3
    }

    public static class ExchangeHelper
    {
        public static List<Exchange> GetExternalExchanges()
        {
            return ((Exchange[])Enum.GetValues(typeof(Exchange)))
                .Except(new List<Exchange> { Exchange.Local })
                .ToList();
        }
    }
}
