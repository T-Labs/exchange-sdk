using Flurl.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.P2P.Deals;

namespace TLabs.ExchangeSdk.WebApp;

public class ClientWebapp
{
    public async Task<IFlurlResponse> SendP2PDealNotification(P2PNotification notification)
    {
        var result = await $"webapp/p2p/deals/notify".InternalApi()
            .PostJsonAsync(notification);
        return result;
    }
}
