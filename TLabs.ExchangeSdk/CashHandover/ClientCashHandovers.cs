using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CashHandover;

public class ClientCashHandovers
{
    private const string BASE_REQUEST_URL = "brokerage/cash-handovers/requests";
    private const string BASE_REQUEST_WORKFLOW_URL = "brokerage/cash-handovers/requests/workflow";
    private const string BASE_DEAL_NUMBERS_URL = "brokerage/cash-handovers/requests/numbers";
    private const string BASE_CLIENTS_URL = "brokerage/cash-handovers/clients";

    public async Task<List<CashHandoverRequestViewModel>> GetRequestsFilteredList(
        string name = null,
        string clientName = null,
        int? dealNumber = null,
        decimal? amount = null,
        List<CashHandoverRequestStatus> statuses = null
    )
    {
        return await $"{BASE_REQUEST_URL}/filtered-list"
            .InternalApi()
            .SetQueryParam(nameof(name), name)
            .SetQueryParam(nameof(clientName), clientName)
            .SetQueryParam(nameof(dealNumber), dealNumber)
            .SetQueryParam(nameof(amount), amount)
            .SetQueryParam(nameof(statuses), statuses)
            .GetJsonAsync<List<CashHandoverRequestViewModel>>();
    }

    public async Task<CashHandoverRequestDto> GetRequestDetails(Guid requestId)
    {
        return await BASE_REQUEST_URL
            .InternalApi()
            .SetQueryParam("id", requestId)
            .GetJsonAsync<CashHandoverRequestDto>();
    }

    public async Task<List<string>> GetCurrencies()
    {
        return await $"{BASE_REQUEST_URL}/currencies".InternalApi().GetJsonAsync<List<string>>();
    }

    public async Task CreateRequestAsync(CreateCashHandoverRequest request)
    {
        await BASE_REQUEST_URL.InternalApi().PostJsonAsync(request);
    }

    public async Task<int> GetDealNumberAsync()
    {
        return await BASE_DEAL_NUMBERS_URL.InternalApi().GetJsonAsync<int>();
    }

    public async Task CreateClientAsync(CashHandoverClient client)
    {
        await BASE_CLIENTS_URL.InternalApi().PostJsonAsync(client);
    }

    public async Task MarkAsIssuedAsync(MarkAsIssuedRequest request)
    {
        await $"{BASE_REQUEST_WORKFLOW_URL}/issue".InternalApi().PutJsonAsync(request);
    }

    public async Task CancelRequestAsync(CancelRequestDto dto)
    {
        await $"{BASE_REQUEST_WORKFLOW_URL}/cancellation".InternalApi().PutJsonAsync(dto);
    }

    public async Task ConfirmPaymentAsync(Guid id)
    {
        await $"{BASE_REQUEST_WORKFLOW_URL}/payment-confirmation"
            .InternalApi()
            .SetQueryParam(nameof(id), id)
            .PutAsync();
    }

    public async Task<List<CashHandoverClient>> GetClientsSelectListAsync(string searchName = null)
    {
        return await BASE_CLIENTS_URL
            .InternalApi()
            .SetQueryParam(nameof(searchName), searchName)
            .GetJsonAsync<List<CashHandoverClient>>();
    }
}
