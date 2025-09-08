using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
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
            DateTimeOffset? from = null, DateTimeOffset? to = null, bool includeDeals = false,
            decimal? minVolume = null)
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
                .SetQueryParam(nameof(minVolume), minVolume)
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

        /// <summary>Delete events for test CurrencyPair</summary>
        public async Task<IFlurlResponse> DeleteTestData(string currencyPairCode)
        {
            var result = await $"marketdata/orders/test-data".InternalApi()
                .SetQueryParam("currencyPairCode", currencyPairCode)
                .DeleteAsync();
            return result;
        }

        public async Task<string> Healthcheck() =>
            await $"marketdata/healthcheck".InternalApi().GetStringAsync();

        public async Task<List<CurrencyPairData>> CurrencyPairsData()
        {
            var result = await $"marketdata/orders/currencypairs-price-and-volume".InternalApi()
                .GetJsonAsync<List<CurrencyPairData>>();
            return result;
        }

        public async Task<List<ResponseOHLC>> GetOHLCData(MarketDataItemRange range, string currencyPairCode,
            DateTime start, DateTime end)
        {
            var result = await $"marketdata/ohlc".InternalApi()
                .SetQueryParam("range", range)
                .SetQueryParam("currencyPairCode", currencyPairCode)
                .SetQueryParam("start", start.ToString("o"))
                .SetQueryParam("end", end.ToString("o"))
                .GetJsonAsync<List<ResponseOHLC>>();
            return result;
        }

        public async Task<List<ResponseOHLC>> GetOHLCLastCandles(string currencyId)
        {
            var result = await $"marketdata/ohlc-last-candles/{currencyId}".InternalApi()
                .GetJsonAsync<List<ResponseOHLC>>(); ;
            return result;
        }

        public async Task<ResponseOHLC> GetOHLCLastCandle(MarketDataItemRange range, string currencyPairCode,
            DateTime? before = null)
        {
            var result = await $"marketdata/ohlc/last-candle".InternalApi()
                .SetQueryParam("range", range)
                .SetQueryParam("currencyPairCode", currencyPairCode)
                .SetQueryParam("before", before?.ToString("o"))
                .GetJsonAsync<ResponseOHLC>();
            return result;
        }

        public async Task<decimal> GetLastDealPrice(string currencyPairCode)
        {
            var priceStr = await $"marketdata/ohlc/last-price".InternalApi()
                .SetQueryParam("currencyPairCode", currencyPairCode)
                .GetStringAsync();
            return decimal.Parse(priceStr);
        }
    }
}
