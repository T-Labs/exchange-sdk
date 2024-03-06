using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class UserInfoDto
{
    public string UserNickname { get; set; }
    public int RecentDealsCount { get; set; }
    public int CompletedRecentDealsCount { get; set; }
    public int AllCompletedDealsCount { get; set; }
    public int CompletedBuysCount { get; set; }
    public int CompletedSellsCount { get; set; }

    public decimal CompletedRecentDealsPercentage => RecentDealsCount == 0
        ? 1
        : ((decimal)CompletedRecentDealsCount / RecentDealsCount).RoundDown(2);

    public int LikesCount { get; set; }
    public int DislikesCount { get; set; }
    public decimal RatingBasedOnReviews { get; set; }

    public int AverageTransferTimeMins { get; set; }
    public int AveragePaymentTimeMins { get; set; }
    public int AccountAgeDays { get; set; }
    public int DaysSinceFirstDeal { get; set; }
    public decimal RecentTradingVolume { get; set; }
    public decimal TotalTradingVolume { get; set; }
}
