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

        public async Task<List<MatchingOrder>> GetOrders(string currencyPairCode = null,
            bool? isBid = null, int? count = null,
            string userId = null, OrderStatusRequest status = OrderStatusRequest.Active,
            DateTimeOffset? from = null, DateTimeOffset? to = null)
        {
            var result = await $"trading/order".InternalApi()
                .SetQueryParam("currencyPairId", currencyPairCode)
                .SetQueryParam("isBid", isBid)
                .SetQueryParam("count", count?.ToString())
                .SetQueryParam("userId", userId)
                .SetQueryParam("status", ((int)status).ToString())
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .GetJsonAsync<List<MatchingOrder>>();
            return result;
        }
    }
}
