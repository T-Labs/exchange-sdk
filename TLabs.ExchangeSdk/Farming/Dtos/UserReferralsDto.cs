using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Farming.Dtos;

public class UserReferralsDto
{
    public string UserName { get; set; }
    public string? AvatarImageId { get; set; }
    public decimal RewardForTheReferral { get; set; }
    public List<UserReferralsDto> SubReferrals { get; set; } = new List<UserReferralsDto>();
}
