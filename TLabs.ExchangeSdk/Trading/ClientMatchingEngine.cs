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

        public async Task<OrderCreateResult> AddOrderAsync(OrderCreateRequest request)
        {
            return await "trading/order".InternalApi().PostJsonAsync<OrderCreateResult>(request);
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

        /// <summary>
        /// Note: orders should generally be canceled through ClientTradingBrokerage because it checks that
        /// user has enough balance frozen to cancel order.
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <param name="toForce">Force cancellation through (ignore Liquidity block)</param>
        public async Task<IFlurlResponse> CancelOrder(Guid orderId, bool toForce = false)
        {
            var matchingEngineResponse = await $"trading/order/{orderId}".InternalApi()
                .SetQueryParam(nameof(toForce), toForce)
                .DeleteAsync();
            return matchingEngineResponse;
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
