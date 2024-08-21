using System;

namespace TLabs.ExchangeSdk.Farming.Dtos;

public class RegistrationDto
{
    public string UserName { get; set; }
    public Guid? ReferralCodeId { get; set; }

    public long TenantId { get; set; }
    public long TgUserId { get; set; }
    public string TgUserName { get; set; }
}
