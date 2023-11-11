using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.P2P;

public class ClientP2P
{
    public async Task<List<Order>> GetOrders(string currencyCode = null,
        int? paymentSystemId = null,
        bool? isBuyingOnExchange = null,
        string userId = null,
        OrderStatus? status = null,
        DateTimeOffset? dateFrom = null,
        DateTimeOffset? dateTo = null)
    {
        var request = $"p2p/orders".InternalApi();

        request = request.SetQueryParam(nameof(currencyCode), currencyCode);
        request = request.SetQueryParam(nameof(paymentSystemId), paymentSystemId);
        request = request.SetQueryParam(nameof(isBuyingOnExchange), isBuyingOnExchange);
        request = request.SetQueryParam(nameof(userId), userId);
        request = request.SetQueryParam(nameof(status), status);
        request = request.SetQueryParam(nameof(dateFrom), dateFrom?.ToString("o"));
        request = request.SetQueryParam(nameof(dateTo), dateTo?.ToString("o"));

        return await request.GetJsonAsync<List<Order>>();
    }

    public async Task<Order> GetOrder(Guid orderId)
    {
        return await $"p2p/orders/{orderId}".InternalApi()
            .GetJsonAsync();
    }

    public async Task<IFlurlResponse> CreateOrder(OrderRequest orderRequest)
    {
        return await $"p2p/orders".InternalApi()
            .PostJsonAsync(orderRequest);
    }

    public async Task<IFlurlResponse> CancelOrder(Guid orderId)
    {
        return await $"p2p/orders/{orderId}".InternalApi()
            .PatchJsonAsync(orderId);
    }

    public async Task<List<Deal>> GetDeals()
    {
        return await $"p2p/deals".InternalApi()
            .GetJsonAsync();
    }

    public async Task<Deal> GetDeal(Guid dealId)
    {
        return await $"p2p/deals/{dealId}".InternalApi()
            .GetJsonAsync();
    }

    public async Task<IFlurlResponse> CreateDeal(DealRequest dealRequest)
    {
        return await $"p2p/deals".InternalApi()
            .PostJsonAsync(dealRequest);
    }

    public async Task<IFlurlResponse> ChangeDealStatus(Guid dealId, DealStatus status)
    {
        return await $"p2p/deals/{dealId}".InternalApi()
            .SetQueryParam(nameof(status), status.ToString())
            .PatchJsonAsync(null);
    }


    public async Task<IFlurlResponse> CreateRequisite(Requisite requisite)
    {
        return await $"p2p/requisites".InternalApi()
            .PostJsonAsync(requisite);
    }


    public async Task<Requisite> GetRequisite(Guid requisiteId)
    {
        return await $"p2p/requisites/{requisiteId}".InternalApi()
            .GetJsonAsync();
    }

    public async Task<List<Requisite>> GetRequisites(string userId)
    {
        return await $"p2p/requisites".InternalApi()
            .SetQueryParam(nameof(userId), userId).GetJsonAsync();
    }

    public async Task<IFlurlResponse> UpdateRequisite(Requisite requisite)
    {
        return await $"p2p/requisites".InternalApi()
            .PutJsonAsync(requisite);
    }

    public async Task<IFlurlResponse> DeleteRequisite(Guid requisiteId)
    {
        return await $"p2p/requisites/{requisiteId}".InternalApi()
            .DeleteJsonAsync(requisiteId);
    }
}
