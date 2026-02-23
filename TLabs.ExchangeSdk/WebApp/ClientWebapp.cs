using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Helpdesk;

namespace TLabs.ExchangeSdk.WebApp;

public class ClientWebapp
{
    public async Task<IFlurlResponse> SendP2PNotification(P2PNotification notification)
    {
        var result = await $"webapp/p2p/notify".InternalApi()
            .PostJsonAsync(notification);
        return result;
    }

    public async Task<IFlurlResponse> SendNotificationsAboutNewTicketReply(AddTicketMessageDto dto)
    {
        var result = await "webapp/tickets/reply-notifications".InternalApi().PostJsonAsync(dto);
        return result;
    }
}
