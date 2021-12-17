using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.LiquidityImport
{
    public class ClientLiquidityMain
    {
        public async Task<List<string>> GetActiveCurrencyPairs(Exchange exchange)
        {
            var result = await $"liquiditymain/parameters/active-currency-pairs/{(int)exchange}".InternalApi()
                .GetJsonAsync<List<string>>();
            return result;
        }

        /// <summary>Is currencyPair import active in atleast 1 external exchange</summary>
        public async Task<bool> IsCurrencyPairActive(string currencyPairCode)
        {
            var result = await $"liquiditymain/parameters/is-active/{currencyPairCode}".InternalApi()
                .GetJsonAsync<string>();
            return bool.Parse(result);
        }
    }
}
