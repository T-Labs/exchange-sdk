using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.P2P;

public class ClientP2P
{
    public async Task<List<Order>> GetOrders()
    {
        return await $"p2p/orders".InternalApi()
            .GetJsonAsync();
    }

    public async Task<List<Order>> GetOrder(Guid orderId)
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
        return await $"p2p/orders".InternalApi()
            .PatchJsonAsync(orderId);
    }
    public async Task<List<Deal>> GetDeals()
    {
        return await $"p2p/deals".InternalApi()
            .GetJsonAsync();
    }
    public async Task<List<Deal>> GetDeal(Guid dealId)
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
        return await $"p2p/deals".InternalApi()
            .PatchJsonAsync(dealId);
    }
}
