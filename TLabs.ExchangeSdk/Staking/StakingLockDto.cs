using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingLockDto
    {
        public Guid UserStakeId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public override string ToString()
            => $"{nameof(StakingLockDto)}({Amount} {CurrencyCode}, userId:{UserId}, stakeId:{UserStakeId})";
    }
}
