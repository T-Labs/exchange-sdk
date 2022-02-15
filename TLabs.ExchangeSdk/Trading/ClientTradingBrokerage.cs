using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Trading
{
    public class ClientTradingBrokerage
    {
        private readonly ClientMatchingEngine _clientMatchingEngine;
        private readonly ClientMarketdata _clientMarketdata;
        private readonly ILogger _logger;

        public ClientTradingBrokerage(ClientMatchingEngine clientMatchingEngine,
            ClientMarketdata clientMarketdata,
            ILogger<ClientTradingBrokerage> logger)
        {
            _clientMatchingEngine = clientMatchingEngine;
            _clientMarketdata = clientMarketdata;
            _logger = logger;
        }

        public async Task<OrderCreateResult> CreateOrder(OrderCreateRequest request)
        {
            var resultStr = await $"brokerage/order".InternalApi()
                .PostJsonAsync<string>(request);
            var decodedString = JsonConvert.DeserializeObject<string>(resultStr);
            var result = JsonConvert.DeserializeObject<OrderCreateResult>(decodedString);
            return result;
        }

        /// <summary>Cancel order</summary>
        /// <param name="toForce">Force cancellation through (ignore Liquidity block)</param>
        public async Task<IFlurlResponse> CancelOrder(Guid orderId, string userId, bool toForce = false)
        {
            return await $"brokerage/order/{orderId}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(toForce), toForce)
                .DeleteAsync();
        }

        public async Task<(int canceled, int total)> CancelAllUserOrders(string userId, bool toForce = false)
        {
            if (userId.NotHasValue())
                throw new ArgumentException("User not specified");
            var orders = await _clientMarketdata.GetOrders(currencyPairCode: null, userId: userId, status: OrderStatusRequest.Active);
            int canceled = 0;
            foreach (var order in orders)
            {
                var result = await CancelOrder(order.Id, userId, toForce).GetQueryResult();
                if (result.Succeeded)
                    canceled++;
            }
            return (canceled, orders.Count);
        }

        public async Task<List<VolumeLimit>> GetOrderVolumeLimits()
        {
            var result = await "brokerage/currencies/limit".InternalApi()
                .GetJsonAsync<List<VolumeLimit>>();
            return result;
        }
    }
}
