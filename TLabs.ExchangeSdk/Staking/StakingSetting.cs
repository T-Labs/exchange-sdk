using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingSetting
    {
        public int Id { get; set; }

        public StakingType Type { get; set; }

        [Required]
        public string BaseCurrencyCode { get; set; }

        [Required]
        public string AccrualCurrencyCode { get; set; }

        /// <summary>
        /// What portion of stake rewards goes to system fund (0 for Passive type)
        /// </summary>
        public decimal SystemProfitPercentage { get; set; }

        /// <summary>
        /// For Passive - used in calculation, for Locked - only estimation in interface
        /// </summary>
        public decimal YearlyAccrualPercentage { get; set; }

        /// <summary>
        /// For Passive - min balance for accruals, for Locked - min stake/unstake action
        /// </summary>
        public decimal MinBaseCurrencyAmount { get; set; }

        /// <summary>
        /// Only for locked type
        /// </summary>
        public int UnlockPeriodDays { get; set; }

        public bool NotificationNeeded { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }

        public decimal DailyAccrualRate => (decimal)Math.Pow(1 + (double)(YearlyAccrualPercentage / 100m), 1.0 / 365) - 1;
    }
}
