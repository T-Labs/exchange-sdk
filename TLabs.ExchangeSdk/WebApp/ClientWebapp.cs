using Flurl.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.WebApp;

public class ClientWebapp
{
    public async Task<IFlurlResponse> SendP2PDealNotification(P2PNotification notification)
    {
        var result = await $"webapp/p2p/notify".InternalApi()
            .PostJsonAsync(notification);
        return result;
    }
}
