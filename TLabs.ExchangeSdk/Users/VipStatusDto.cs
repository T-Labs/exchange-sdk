using System;

namespace TLabs.ExchangeSdk.Users
{
    public class VipStatusDto
    {
        public bool IsVip { get; set; }
        public DateTimeOffset? VipActivatedAt { get; set; }
        public DateTimeOffset? VipGracePeriodEndsAt { get; set; }
    }

    public class SetVipStatusDto
    {
        public bool IsVip { get; set; }
        public DateTimeOffset? VipGracePeriodEndsAt { get; set; }
    }

    public class VipAssistantDto
    {
        public string Name { get; set; }
    }
}
