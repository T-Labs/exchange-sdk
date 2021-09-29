using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.LiquidityImport
{
    public class ClientLiquidityConnectors
    {
        public string GetConnectorPath(Exchange exchange) => $"liquidity{exchange.ToString().ToLower()}";

        /// <summary>Get CurrencyPair codes list without delimeters. Example: "BCHBTC", "BTCUSDT"</summary>
        public async Task<List<string>> GetCurrencyPairs(Exchange exchange)
        {
            if (exchange != Exchange.Binance)
                throw new ArgumentException($"Only Binance exchange allowed");
            var result = await $"{GetConnectorPath(exchange)}/external/currency-pairs".InternalApi()
                .GetJsonAsync<List<string>>();
            return result;
        }

        /// <summary>Get prices at start of each day</summary>
        public async Task<List<(DateTimeOffset date, decimal amount)>> GetDailyPrices(Exchange exchange, string currencyCode,
            DateTimeOffset from, DateTimeOffset to)
        {
            if (exchange != Exchange.Binance)
                throw new ArgumentException($"Only Binance exchange allowed");
            var result = await $"{GetConnectorPath(exchange)}/external/prices-daily".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(from), from.ToString("o"))
                .SetQueryParam(nameof(to), to.ToString("o"))
                .GetJsonAsync<List<(DateTimeOffset date, decimal amount)>>();
            return result;
        }

        /// <summary>Get last snapshots by days. Only implemented for Binance</summary>
        /// <param name="count">Number of daily snapshots to load (5-30)</param>
        public async Task<List<BalanceSnapshotDto>> GetBalancesSnapshots(Exchange exchange, string apiKey, string apiSecret, int count = 5)
        {
            if (exchange != Exchange.Binance)
                throw new ArgumentException($"Only Binance exchange allowed");
            var result = await $"{GetConnectorPath(exchange)}/external/balances-snapshots".InternalApi()
                .SetQueryParam(nameof(apiKey), apiKey)
                .SetQueryParam(nameof(apiSecret), apiSecret)
                .SetQueryParam(nameof(count), count)
                .GetJsonAsync<List<BalanceSnapshotDto>>();
            return result;
        }
    }
}
