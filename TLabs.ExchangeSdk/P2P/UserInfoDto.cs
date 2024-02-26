using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class UserInfoDto
{
    public string UserNickname { get; set; }
    public int CompletedBuys { get; set; }
    public int CompletedSells { get; set; }
    public int HighRatingBuys { get; set; }
    public int HighRatingSells { get; set; }
    public int CompletedDeals30Days { get; set; }
    public int AllDeals30Days { get; set; }

    public decimal CompletedDealsPercentage30Days => AllDeals30Days == 0
        ? 100
        : ((decimal)CompletedDeals30Days / AllDeals30Days).RoundDown(2);
}