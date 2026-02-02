using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingSetting
    {
        public int Id { get; set; }

        [Required]
        public string BaseCurrencyCode { get; set; }

        [Required]
        public string AccrualCurrencyCode { get; set; }

        /// <summary>
        /// What portion of stake rewards goes to system fund
        /// </summary>
        public decimal SystemProfitPercentage { get; set; }

        /// <summary>
        /// Estimation in interface
        /// </summary>
        public decimal YearlyAccrualPercentage { get; set; }

        /// <summary>
        /// Min stake/unstake action amount
        /// </summary>
        public decimal MinBaseCurrencyAmount { get; set; }

        public int LockPeriodDays { get; set; }

        public bool NotificationNeeded { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }

        public decimal DailyAccrualRate => (decimal)Math.Pow(1 + (double)(YearlyAccrualPercentage / 100m), 1.0 / 365) - 1;
    }
}
