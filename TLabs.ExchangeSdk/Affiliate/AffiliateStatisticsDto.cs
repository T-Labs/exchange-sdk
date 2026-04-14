namespace TLabs.ExchangeSdk.Affiliate;

public class AffiliateStatisticsDto
{
    public double AverageReferralsPerUser { get; set; }
    public double AverageReferralsPerInvitedUser { get; set; }
    public int UsersWhoNeverStakedCount { get; set; }
    public int InvitedUsersWhoNeverStakedCount { get; set; }
    public int UsersWithNoDirectReferralsCount { get; set; }
    public int InvitedUsersWithNoDirectReferralsCount { get; set; }
}
