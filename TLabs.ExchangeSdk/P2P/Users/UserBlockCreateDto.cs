namespace TLabs.ExchangeSdk.P2P.Users;

public class UserBlockCreateDto
{
    public string UserId { get; set; }
    public string BlockedUserId { get; set; }
    public string Comment { get; set; }
}
