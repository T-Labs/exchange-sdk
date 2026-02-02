using System;

namespace TLabs.ExchangeSdk.Staking
{
    public class UserStake
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int StakingSettingId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTimeOffset DateStarted { get; set; }
        public DateTimeOffset DateEnding { get; set; }
        public DateTimeOffset? DateReleased { get; set; }
    }
}
