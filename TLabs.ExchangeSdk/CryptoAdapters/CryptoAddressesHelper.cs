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
                : new Regex("/^D[5-9A-HJ-NP-U]{1}[1-9a-km-zA-HJ-NP-Z]{32}$/").IsMatch(adapterCode) ? true // doge CHECK
                : new Regex("^(?:[13]{1}[a-km-zA-HJ-NP-Z1-9]{26,33}|bc1[a-z0-9]{39,59})$").IsMatch(adapterCode) ? true // btc CHECK
                : new Regex("T[A-Za-z1-9]{33}").IsMatch(adapterCode) ? true : false; // trx
        }
    }
}
