using System.Collections.Generic;
using System.Threading.Tasks;
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

    public async Task CreateAsync(CashExchange cashExchange)
    {
        await BASE_EXCHANGE_URL.InternalApi().PostJsonAsync(cashExchange);
    }
}
