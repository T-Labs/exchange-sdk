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

        public async Task<CurrencyOffering> Get(string code)
        {
            if (code.NotHasValue())
                throw new ArgumentNullException(nameof(code));
            var result = await $"{BaseUrl}/{code}".InternalApi()
                .GetJsonAsync<CurrencyOffering>();
            return result;
        }

        public async Task<decimal> GetTotalSales(string code)
        {
            if (code.NotHasValue())
                throw new ArgumentNullException(nameof(code));
            var result = await $"{BaseUrl}/{code}/total-sales".InternalApi()
                .GetJsonAsync<string>();
            return decimal.Parse(result);
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

        public async Task<List<CurrencyOfferingPurchase>> GetPurchases(string userId, string currencyCode,
            CurrencyOfferingPurchaseStatus status)
        {
            var result = await $"{BaseUrl}/purchases".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(status), status)
                .GetJsonAsync<List<CurrencyOfferingPurchase>>();
            return result;
        }

        public async Task<decimal> GetPurchasePrice(string currencyCode, string payingCurrencyCode)
        {
            var result = await $"{BaseUrl}/purchases/price".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(payingCurrencyCode), payingCurrencyCode)
                .GetStringAsync();
            return decimal.Parse(result);
        }

        public async Task MakePurchase(CurrencyOfferingPurchase model)
        {
            var result = await $"{BaseUrl}/purchases".InternalApi()
                .PostJsonAsync(model);
        }
    }
}
