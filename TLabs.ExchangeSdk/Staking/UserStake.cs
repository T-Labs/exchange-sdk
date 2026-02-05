using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Staking
{
    public enum UserStakingStatus
    {
        Requested = 10,
        Active = 20,
        Finished = 30,
        StakingFailed = 40,
    }

    public class UserStake
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public UserStakingStatus Status { get; set; }

        public Guid StakingSettingId { get; set; }
        public StakingSetting StakingSetting { get; set; }

        public decimal Amount { get; set; }

        public decimal YearlyAccrualPercentage { get; set; }

        public decimal SingleAccrualAmount { get; set; }

        public DateTimeOffset DateStarted { get; set; }

        public DateTimeOffset DateEnding { get; set; }

        public DateTimeOffset? DateReleased { get; set; }

        public DateTimeOffset DateLastAccrual { get; set; }

        public decimal SingleAccrualRate => (decimal)Math.Pow(1 + (double)(YearlyAccrualPercentage / 100m), 1.0 / 365 / 3) - 1;

        public override string ToString() => $"{nameof(UserStake)}(Id:{Id}, userId:{UserId}, status:{Status}, settingId:{StakingSettingId}, " +
            $"amount:{Amount}, yearlyRate:{YearlyAccrualPercentage}%, singleAccrual:{SingleAccrualAmount}, " +
            $"{DateStarted:s} - {DateEnding:s}, released:{DateReleased}, lastAccrual:{DateLastAccrual:s})";
    }
}
