namespace TLabs.ExchangeSdk.P2P;

public class UserBlock
{
    public string UserId { get; set; }
    public string BlockedUserId { get; set; }

    public UserBlock()
    {
    }

    public UserBlock(string userId, string blockedUserId)
    {
        UserId = userId;
        BlockedUserId = blockedUserId;
    }
}
