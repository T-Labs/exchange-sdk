using System;
using System.ComponentModel.DataAnnotations;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingSetting
    {
        public Guid Id { get; set; }

        [Required]
        public string BaseCurrencyCode { get; set; }

        /// <summary>Same as BaseCurrencyCode for now</summary>
        [Required]
        public string AccrualCurrencyCode { get; set; }

        public decimal YearlyAccrualPercentage { get; set; }

        public decimal MinAmountUsdt { get; set; }

        public Currency BaseCurrency { get; set; }

        public decimal? MinAmountBaseCurrency { get; set; }

        public int LockPeriodDays { get; set; }

        public bool NotificationNeeded { get; set; }

        /// <summary>How much will go to AccountChart UserBonuses</summary>
        public decimal PercentageToUserBonuses { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
