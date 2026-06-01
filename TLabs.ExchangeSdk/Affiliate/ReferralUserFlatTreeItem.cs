namespace TLabs.ExchangeSdk.Affiliate;

public class ReferralUserFlatTreeItem
{
    public string UserId { get; set; }
    public string ParentUserId { get; set; }
    public string UserInviteCode { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string PublicId { get; set; }
    public bool HasMoreRelatives { get; set; }
}
