using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.BinanceHandling
{
    public class ClientBinanceHandling
    {
        private readonly ILogger _logger;

        private const string BaseUrl = "brokerage/binance-handling";
        public const string BaseCurrency = "C3";

        public ClientBinanceHandling(
            ILogger<ClientBinanceHandling> logger)
        {
            _logger = logger;
        }

        public async Task<List<BinanceHandlingAccount>> GetAccounts(string userId = null, BinanceHandlingBot? bot = null,
            string mainCurrency = null)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(bot), bot.HasValue ? (int)bot : "")
                .SetQueryParam(nameof(mainCurrency), mainCurrency)
                .GetJsonAsync<List<BinanceHandlingAccount>>();
            return result;
        }

        public async Task<BinanceHandlingAccount> AddAccount(BinanceHandlingAccount account)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .PostJsonAsync<BinanceHandlingAccount>(account);
            return result;
        }
    }
}
