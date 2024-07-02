using System;

namespace TLabs.ExchangeSdk.Farming.Dtos;

public class RegistrationDto
{
   public long TenantId { get; set; }
   public string UserName { get; set; }
   public string? PhotoId { get; set; }
   public Guid ReferralCodeId { get; set; }

}
