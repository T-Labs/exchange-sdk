using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Trading
{
    public class TradingBrokerageClient
    {
        public TradingBrokerageClient()
        {
        }

        public async Task<OrderCreateResult> CreateOrder(OrderCreateRequest request)
        {
            var resultStr = await $"brokerage/order".InternalApi()
                .PostJsonAsync<string>(request);
            var decodedString = JsonConvert.DeserializeObject<string>(resultStr);
            var result = JsonConvert.DeserializeObject<OrderCreateResult>(decodedString);
            return result;
        }

        public async Task<IFlurlResponse> CancelOrder(Guid orderId, string userId)
        {
            return await $"brokerage/order/{orderId}?userId={userId}".InternalApi()
                .DeleteAsync();
        }

        public async Task<List<VolumeLimit>> GetOrderVolumeLimits()
        {
            var result = await "brokerage/currencies/limit".InternalApi()
                .GetJsonAsync<List<VolumeLimit>>();
            return result;
        }
    }
}
