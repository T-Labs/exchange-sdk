using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Trading
{
    public class ClientMatchingEngine
    {
        public ClientMatchingEngine()
        {
        }

        /// <summary>Get active order (if exists in pools), without deals</summary>
        /// <param name="currencyPairCode">Optional, if null then all pools will be checked</param>
        public async Task<MatchingOrder> GetActiveOrder(Guid id, string currencyPairCode = null)
        {
            var result = await $"trading/order/{id}".InternalApi()
                .SetQueryParam("currencyPairCode", currencyPairCode)
                .GetJsonAsync<MatchingOrder>();
            return result;
        }

        /// <summary>Delete events for test CurrencyPair</summary>
        public async Task<IFlurlResponse> DeleteTestData(string currencyPairCode)
        {
            var result = await $"trading/order/test-data".InternalApi()
                .SetQueryParam("currencyPairCode", currencyPairCode)
                .DeleteAsync();
            return result;
        }

        public async Task<string> Healthcheck() =>
            await $"trading/healthcheck".InternalApi().GetStringAsync();
    }
}
