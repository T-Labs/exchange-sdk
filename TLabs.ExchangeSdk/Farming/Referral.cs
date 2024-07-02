namespace TLabs.ExchangeSdk.Farming;

public class Referral
{
    public long UserId { get; set; }
    public long ParentUserId { get; set; }
    public User User { get; set; }
    public User ParentUser { get; set; }
}
