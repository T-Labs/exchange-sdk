using System;

namespace TLabs.ExchangeSdk.Staking
{
    public class CreateUserStakeDto
    {
        public string UserId { get; set; }
        public Guid StakingSettingId { get; set; }
        public decimal Amount { get; set; }
        public override string ToString()
            => $"{nameof(CreateUserStakeDto)}({Amount}, userId:{UserId}, settingId:{StakingSettingId})";
    }
}
