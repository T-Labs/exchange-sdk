using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.CashDeposits;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings
{
    public class ClientCurrencyListings
    {
        const string baseUrl = "brokerage/currency-listings";

        public async Task<List<CurrencyListing>> GetList(string userId = null, CurrencyListingStatus? status = null)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(userId), userId?.Trim().NullIfEmpty())
                .SetQueryParam(nameof(status), status == null ? "" : ((int)status).ToString())
                .GetJsonAsync<List<CurrencyListing>>();
            return result;
        }

        public async Task<CurrencyListing> Get(string currencyCode)
        {
            var result = await $"{baseUrl}/{currencyCode}".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode?.Trim())
                .GetJsonAsync<CurrencyListing>();
            return result;
        }

        public async Task<CurrencyListing> Create(CurrencyListing model)
        {
            var createdListing = await $"{baseUrl}/{model.CurrencyCode}".InternalApi()
                .PutJsonAsync<CurrencyListing>(model);
            return createdListing;
        }

        public async Task<QueryResult> ChangeStatus(string currencyCode, CurrencyListingStatus newStatus)
        {
            var result = await $"{baseUrl}/{currencyCode}".InternalApi()
                .SetQueryParam(nameof(newStatus), newStatus)
                .PostJsonAsync(null).GetQueryResult();
            return result;
        }

        public async Task<CurrencyListingSettings> GetSettings()
        {
            var result = await $"{baseUrl}/settings".InternalApi()
                .GetJsonAsync<CurrencyListingSettings>();
            return result;
        }
    }
}
