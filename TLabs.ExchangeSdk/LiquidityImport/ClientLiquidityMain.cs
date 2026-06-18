using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
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

        public virtual async Task<List<OrderbookOrder>> GetOrderbookAsync(Exchange exchange, string currencyPairCode)
        {
            return await $"liquiditymain/orderbook/{(int)exchange}/{currencyPairCode}"
                .InternalApi()
                .GetJsonAsync<List<OrderbookOrder>>();
        }
    }
}
