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
        return await $"p2p/api/orders/orders".InternalApi()
            .GetJsonAsync();
    }

    public async Task<IFlurlResponse> CreateOrder(OrderRequest orderRequest)
    {
        return await $"p2p/api/orders/order".InternalApi()
            .PostJsonAsync(orderRequest);
    }

    public async Task<IFlurlResponse> CancelOrder(Guid orderId)
    {
        return await $"p2p/api/orders/order".InternalApi()
            .PatchJsonAsync(orderId);
    }

    public async Task<List<Deal>> GetDeals()
    {
        return await $"p2p/api/deals/deals".InternalApi()
            .GetJsonAsync();
    }

    public async Task<IFlurlResponse> CreateDeal(DealRequest dealRequest)
    {
        return await $"p2p/api/deals/deal".InternalApi()
            .PostJsonAsync(dealRequest);
    }

    public async Task<IFlurlResponse> CancelDeal(Guid dealId)
    {
        return await $"p2p/api/deals/deal".InternalApi()
            .PatchJsonAsync(dealId);
    }
}
