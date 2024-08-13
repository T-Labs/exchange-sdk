using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.News;
using TLabs.ExchangeSdk.News.Dtos;

namespace TLabs.ExchangeSdk.Currencies
{
    public class ClientCurrencies
    {
        public async Task<IFlurlResponse> SetCurrencyPairVisibility(string currencyPairCode, bool newValue)
        {
            var result = await $"depository/currency-pairs/user-showing-status/{currencyPairCode}".InternalApi()
                .PutJsonAsync(newValue);
            return result;
        }
    }
}
