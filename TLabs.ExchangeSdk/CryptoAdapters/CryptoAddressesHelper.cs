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
        public static bool IsTronAddress(string address)
        {
            return new Regex("T[A-Za-z1-9]{33}").IsMatch(address);
        }
    }
}
