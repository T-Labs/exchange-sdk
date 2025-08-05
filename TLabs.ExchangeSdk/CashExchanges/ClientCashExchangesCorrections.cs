using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CashExchanges;

public class ClientCashExchangesCorrections
{
    private const string BASE_URL = "brokerage/cash-exchanges/corrections";

    public async Task<List<Correction>> GetAsync(DateTimeOffset date)
    {
        return await BASE_URL
            .InternalApi()
            .SetQueryParam(nameof(date), date)
            .GetJsonAsync<List<Correction>>();
    }

    public async Task<Guid> CreateAsync(Correction correction)
    {
        return await BASE_URL.InternalApi().PostJsonAsync<Guid>(correction);
    }

    public async Task UpdateAsync(Correction correction)
    {
        await BASE_URL.InternalApi().PutJsonAsync(correction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await BASE_URL.InternalApi().SetQueryParam("id", id).DeleteAsync();
    }
}
