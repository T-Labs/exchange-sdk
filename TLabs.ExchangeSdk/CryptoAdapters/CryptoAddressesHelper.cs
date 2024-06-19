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
        public static bool IsValidAddress(string adapterCode, string adapterAddress) => adapterCode switch
        {
            "bsc" => new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterAddress),
            "eth" => new Regex("^0x[a-fA-F0-9]{40}$").IsMatch(adapterAddress),
            "doge" => new Regex("^D[5-9A-HJ-NP-U]{1}[1-9a-km-zA-HJ-NP-Z]{32}$").IsMatch(adapterAddress),
            "btc" => new Regex("^(?:[13]{1}[a-km-zA-HJ-NP-Z1-9]{26,33}|bc1[a-z0-9]{39,59})$").IsMatch(adapterAddress),
            "trx" => new Regex("^T[A-Za-z1-9]{33}$").IsMatch(adapterAddress),
            "ton" => new Regex("^[A-Za-z0-9\\-_]{48}$").IsMatch(adapterAddress),
            "dash" => new Regex("^X[1-9A-HJ-NP-Za-km-z]{33}$").IsMatch(adapterAddress),
            "ltc" => new Regex("^[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}$").IsMatch(adapterAddress),
            "del" => new Regex("^dx1[ac-hj-np-z0-9]{38}$").IsMatch(adapterAddress),
            "pzm" => new Regex("^PRIZM-[A-Z2-9]{4}-[A-Z2-9]{4}-[A-Z2-9]{4}-[A-Z2-9]{5}$").IsMatch(adapterAddress),
            "umi" => new Regex("^umi1[ac-np-z0-9]{58}$").IsMatch(adapterAddress),
            _ => false
        };
    }
}
