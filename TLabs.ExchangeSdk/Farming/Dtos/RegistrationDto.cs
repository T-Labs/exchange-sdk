using System;

namespace TLabs.ExchangeSdk.Farming.Dtos;

public class RegistrationDto
{
    public long TenantId { get; set; }
    public string UserName { get; set; }
    public string? AvatarImageId { get; set; }
    public Guid? ReferralCodeId { get; set; }
}
