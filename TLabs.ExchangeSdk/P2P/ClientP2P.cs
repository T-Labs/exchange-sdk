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
        int? paymentMethod = null,
        bool? isBuyingOnExchange = null,
        string userId = null,
        OrderStatus? status = null,
        DateTimeOffset? dateFrom = null,
        DateTimeOffset? dateTo = null)
    {
        var request = $"p2p/orders".InternalApi();

        request = request.SetQueryParam("currencyCode", currencyCode);
        request = request.SetQueryParam("paymentMethod", paymentMethod);
        request = request.SetQueryParam("isBuyingOnExchange", isBuyingOnExchange);
        request = request.SetQueryParam("userId", userId);
        request = request.SetQueryParam("status", status);
        request = request.SetQueryParam("dateFrom", dateFrom?.ToString("o"));
        request = request.SetQueryParam("dateTo", dateTo?.ToString("o"));

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

    public async Task<IFlurlResponse> CancelDeal(Guid dealId)
    {
        return await $"p2p/deals/{dealId}".InternalApi()
            .PatchJsonAsync(dealId);
    }
}
