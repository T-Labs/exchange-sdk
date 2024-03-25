using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class OrderUserInfo
{
    public string UserId { get; set; }
    public int RecentDealsCount { get; set; }
    public int CompletedRecentDealsCount { get; set; }

    public decimal CompletedRecentDealsPercentage => RecentDealsCount == 0
        ? 1
        : ((decimal)CompletedRecentDealsCount / RecentDealsCount).RoundDown(2);

    public int DaysSinceRegistration { get; set; }
}
