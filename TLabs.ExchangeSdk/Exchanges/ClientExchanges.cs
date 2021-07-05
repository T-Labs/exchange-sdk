using Flurl.Http;
using System;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Exchanges
{
    public class ClientExchanges
    {
        public async Task<ExchangePrice> GetExchangePrice(Guid id)
        {
            var result = await $"brokerage/exchange/price/{id}".InternalApi()
                .GetJsonAsync<ExchangePrice>();
            return result;
        }

        public async Task<ExchangePrice> EstimateExchangePrice(ExchangePriceRequest request)
        {
            var result = await $"brokerage/exchange/price".InternalApi()
                .PostJsonAsync<ExchangePrice>(request);
            return result;
        }

        public async Task<Guid> CreateExchange(ExchangeRequest request)
        {
            var result = await $"brokerage/exchange".InternalApi()
                .PostJsonAsync<Guid>(request);
            return result;
        }

        public async Task<PagedList<ExchangeOrder>> GetExchanges(string userId = null, ExchangeStatus? status = null,
            int page = 1, int pageSize = 20)
        {
            var result = await $"brokerage/exchange".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(status), status)
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<ExchangeOrder>>();
            return result;
        }
    }
}
