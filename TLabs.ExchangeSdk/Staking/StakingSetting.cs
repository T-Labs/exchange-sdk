using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingSetting
    {
        public int Id { get; set; }

        [Required]
        public string BaseCurrencyCode { get; set; }

        /// <summary>Same as BaseCurrencyCode for now</summary>
        [Required]
        public string AccrualCurrencyCode { get; set; }

        public decimal YearlyAccrualPercentage { get; set; }

        public decimal MinBaseCurrencyAmount { get; set; }

        public int LockPeriodDays { get; set; }

        public bool NotificationNeeded { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
