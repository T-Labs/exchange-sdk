using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CashHandover;

public class ClientCashHandovers
{
    private const string BASE_REQUEST_URL = "brokerage/cash-handovers/requests";
    private const string BASE_DEAL_NUMBERS_URL = "brokerage/cash-handovers/requests/numbers";
    private const string BASE_CLIENTS_URL = "brokerage/cash-handovers/clients";

    public async Task<List<CashHandoverRequestViewModel>> GetRequestsFilteredList(
        string firstName = null,
        string lastName = null,
        string clientName = null,
        string dealNumber = null,
        decimal? amount = null
    )
    {
        return await $"{BASE_REQUEST_URL}/filtered-list"
            .InternalApi()
            .SetQueryParam(nameof(firstName), firstName)
            .SetQueryParam(nameof(lastName), lastName)
            .SetQueryParam(nameof(clientName), clientName)
            .SetQueryParam(nameof(dealNumber), dealNumber)
            .SetQueryParam(nameof(amount), amount)
            .GetJsonAsync<List<CashHandoverRequestViewModel>>();
    }

    public async Task<CashHandoverRequestDto> GetRequestDetails(Guid requestId)
    {
        return await BASE_REQUEST_URL
            .InternalApi()
            .SetQueryParam("id", requestId)
            .GetJsonAsync<CashHandoverRequestDto>();
    }

    public async Task CreateRequestAsync(CreateCashHandoverRequest request)
    {
        await BASE_REQUEST_URL.InternalApi().PostJsonAsync(request);
    }

    public async Task<string> GenerateDealNumberAsync()
    {
        var response = await BASE_DEAL_NUMBERS_URL.InternalApi().PostAsync();
        return await response.GetStringAsync();
    }

    public async Task CreateClientAsync(CashHandoverClient client)
    {
        await BASE_CLIENTS_URL.InternalApi().PostJsonAsync(client);
    }

    public async Task MarkAsIssuedAsync(MarkAsIssuedRequest request)
    {
        await $"{BASE_REQUEST_URL}/issue".InternalApi().PutJsonAsync(request);
    }

    public async Task CancelRequestAsync(CancelRequestDto dto)
    {
        await $"{BASE_REQUEST_URL}/cancellation".InternalApi().PutJsonAsync(dto);
    }

    public async Task<List<CashHandoverClient>> GetClientsSelectListAsync()
    {
        return await $"{BASE_CLIENTS_URL}/all"
            .InternalApi()
            .GetJsonAsync<List<CashHandoverClient>>();
    }
}
