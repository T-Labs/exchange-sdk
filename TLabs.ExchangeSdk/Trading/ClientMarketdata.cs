using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Trading
{
    public class ClientMarketdata
    {
        public ClientMarketdata()
        {
        }

        public async Task<List<MarketdataOrder>> GetOrders(string currencyPairCode = null, bool? isBid = null, int? count = null,
            string userId = null, OrderStatusRequest status = OrderStatusRequest.Active,
            DateTimeOffset? from = null, DateTimeOffset? to = null, bool includeDeals = false)
        {
            var result = await $"marketdata/orders".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam("currencyPairId", currencyPairCode)
                .SetQueryParam("isBid", isBid)
                .SetQueryParam("count", count?.ToString())
                .SetQueryParam("userId", userId)
                .SetQueryParam("status", ((int)status).ToString())
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .SetQueryParam(nameof(includeDeals), includeDeals)
                .GetJsonAsync<List<MarketdataOrder>>();
            return result;
        }

        public async Task<MarketdataOrder> GetOrder(Guid id)
        {
            var result = await $"marketdata/orders/order/{id}".InternalApi()
                .GetJsonAsync<MarketdataOrder>();
            return result;
        }

        public async Task<List<MarketdataDeal>> GetDeals(List<string> userIds = null,
            string currencyPairCode = null, DateTimeOffset? sinceDate = null, DateTimeOffset? toDate = null,
            int pageNumber = 1, int pageSize = 20, bool includeOrders = false)
        {
            var result = await $"marketdata/orders/dealresponses".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam("currencyPairId", currencyPairCode)
                .SetQueryParam(nameof(sinceDate), sinceDate?.ToString("o"))
                .SetQueryParam(nameof(toDate), toDate?.ToString("o"))
                .SetQueryParam(nameof(pageNumber), pageNumber)
                .SetQueryParam(nameof(pageSize), pageSize)
                .SetQueryParam(nameof(includeOrders), includeOrders)
                .PostJsonAsync<List<MarketdataDeal>>(userIds);
            return result;
        }

        public async Task<MarketdataDeal> GetDeal(Guid id)
        {
            var result = await $"marketdata/deals/{id}".InternalApi()
                .GetJsonAsync<MarketdataDeal>();
            return result;
        }

        public async Task<List<Quote>> GetQuotes()
        {
            var quotes = await $"marketdata/quotes".InternalApi().GetJsonAsync<List<Quote>>();
            return quotes;
        }

        public async Task<List<PriceSpread>> GetPriceSpreads(List<string> currencyPairCodes)
        {
            var result = await $"marketdata/orders/spreads/{string.Join(",", currencyPairCodes)}"
                .InternalApi().GetJsonAsync<List<PriceSpread>>();
            return result;
        }

        public async Task<PriceSpread> GetPriceSpread(string currencyPairCode)
        {
            var priceSpread = (await GetPriceSpreads(new List<string>() { currencyPairCode }))
                .First(_ => _.CurrencyPair == currencyPairCode);
            return priceSpread;
        }
    }
}
