using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CashExchanges;

public class ClientCashExchanges
{
    private const string BASE_EXCHANGE_URL = "brokerage/cash-exchanges";

    public async Task<List<CashExchange>> GetAsync()
    {
        return await BASE_EXCHANGE_URL.InternalApi().GetJsonAsync<List<CashExchange>>();
    }

    public async Task<CashExchangeRates> GetRatesAsync(DateTimeOffset date)
    {
        return await $"{BASE_EXCHANGE_URL}/rates"
            .InternalApi()
            .SetQueryParam(nameof(date), date)
            .GetJsonAsync<CashExchangeRates>();
    }

    public async Task CreateAsync(CashExchange cashExchange)
    {
        await BASE_EXCHANGE_URL.InternalApi().PostJsonAsync(cashExchange);
    }

    public async Task<CashExchangeSummary> GetSummaryAsync(DateTimeOffset date)
    {
        return await $"{BASE_EXCHANGE_URL}/summary"
            .SetQueryParam(nameof(date), date)
            .InternalApi()
            .GetJsonAsync<CashExchangeSummary>();
    }
}
