using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingAccrual
    {
        public int Id { get; set; }

        public int StakingSettingId { get; set; }
        public StakingSetting StakingSetting { get; set; }

        public DateTimeOffset DatePlanned { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public int TotalUsers { get; set; }

        /// <summary>
        /// Total daily rewards sum (computed from user stakes * daily rate)
        /// </summary>
        public decimal? LockedRewardsSum { get; set; }

        public override string ToString() => $"{nameof(StakingAccrual)}(Id: {Id}, {StakingSetting?.BaseCurrencyCode}, dividends: {StakingSetting?.AccrualCurrencyCode}, " +
            $"PlannedDate: {DatePlanned.ToString("s")}, Users:{TotalUsers} " +
            $"{(LockedRewardsSum.HasValue ? $", LockedRewardsSum:{LockedRewardsSum}" : "")})";
    }
}
