using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CurrencyOfferings
{
    public class ClientCurrencyOfferings
    {
        private readonly ILogger _logger;

        private const string BaseUrl = "brokerage/currency-offerings";

        public ClientCurrencyOfferings(
            ILogger<ClientCurrencyOfferings> logger)
        {
            _logger = logger;
        }

        public async Task<List<CurrencyOffering>> GetAll()
        {
            var result = await $"{BaseUrl}".InternalApi()
                .GetJsonAsync<List<CurrencyOffering>>();
            return result;
        }

        public async Task<CurrencyOffering> Add(CurrencyOffering model)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .PutJsonAsync<CurrencyOffering>(model);
            return result;
        }

        public async Task<CurrencyOffering> Update(CurrencyOffering model)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .PostJsonAsync<CurrencyOffering>(model);
            return result;
        }
    }
}
