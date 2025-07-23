using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CashExchanges;

public class ClientCashExchanges
{
    private const string BASE_EXCHANGE_URL = "brokerage/cash-exchanges";

    public async Task Create(CashExchange cashExchange)
    {
        await BASE_EXCHANGE_URL.InternalApi().PostJsonAsync(cashExchange);
    }
}
