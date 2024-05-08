using TLabs.ExchangeSdk.P2P.Deals;

namespace TLabs.ExchangeSdk.WebApp;

public class P2PNotification
{
    public string Target { get; set; }
    public Deal Deal { get; set; }

    public P2PNotification()
    {
    }

    public P2PNotification(string target, Deal deal)
    {
        Target = target;
        Deal = deal;
    }
}

public static class P2PNotificationTarget
{
    public const string P2PDeal = "P2PDeal";
    public const string P2PChat = "P2PChat";
    public const string P2PSellerDispute = "P2PSellerDispute";
}
