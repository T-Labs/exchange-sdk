using TLabs.ExchangeSdk.P2P.Deals;

namespace TLabs.ExchangeSdk.WebApp;

public class P2PNotification
{
    public string Target { get; set; }
    public Deal Deal { get; set; }
}

public static class P2PNotificationTarget
{
    public const string P2PDeal = "P2PDeal";
}
