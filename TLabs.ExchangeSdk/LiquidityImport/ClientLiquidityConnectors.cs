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

        /// <summary>Get last snapshots by days. Only implemented for Binance</summary>
        public async Task<List<BalanceSnapshotDto>> GetBalancesSnapshots(Exchange exchange, string apiKey, string apiSecret)
        {
            if (exchange != Exchange.Binance)
                throw new ArgumentException($"Only Binance exchange allowed");
            var result = await $"{GetConnectorPath(exchange)}/external/balances-snapshots".InternalApi()
                .SetQueryParam(nameof(apiKey), apiKey)
                .SetQueryParam(nameof(apiSecret), apiSecret)
                .GetJsonAsync<List<BalanceSnapshotDto>>();
            return result;
        }
    }
}
