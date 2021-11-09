using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.Ordering
{
    public class ClientOrdering
    {
        public ClientOrdering()
        {
        }

        public async Task<IFlurlResponse> SendDeal(MatchingDeal deal)
        {
            return await $"dealending/deal".InternalApi()
                .PostJsonAsync(deal);
        }

        public async Task<IFlurlResponse> CompleteOrderCancelling(MatchingOrder order)
        {
            return await $"dealending/orders/cancel".InternalApi()
                .PostJsonAsync(order);
        }
    }
}
