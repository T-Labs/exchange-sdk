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
            return new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterCode) ? true
                : new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterCode) ? true // eth bsc
                : new Regex("T[A-Za-z1-9]{33}").IsMatch(adapterCode) ? true : false; // trx
        }
    }
}
