using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public static class CryptoAddressesHelper
    {
        public static bool IsValidAddress(string adapterCode)
        {
            return adapterCode switch
            {
                "btc" => new Regex("/^0x[a-fA-F0-9]{40}$/").IsMatch(adapterCode),
                "eth" => new Regex("/^0x[a-fA-F0-9]{40}$/").IsMatch(adapterCode),
                "trx" => new Regex("T[A-Za-z1-9]{33}").IsMatch(adapterCode),
                _ => false
            };
        }
    }
}
