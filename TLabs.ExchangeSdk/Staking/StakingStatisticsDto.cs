using System;

namespace TLabs.ExchangeSdk.Staking;

public class StakingStatisticsDto
{
    public decimal TotalUsersAmountInStaking { get; set; }
    public decimal AverageStakeAmountPerUser { get; set; }
    public StakingSettingsStatisticsDto MostPopularStakingSettings { get; set; }
    public decimal AverageStakeAmountForMostPopularStakingOption { get; set; }
}

public class StakingSettingsStatisticsDto
{
    public Guid StakingSettingId { get; set; }
    public string BaseCurrencyCode { get; set; }
    public int LockPeriodDays { get; set; }
    public double YearlyAccrualPercentage { get; set; }
    public decimal MinAmountBaseCurrency { get; set; }
    public decimal PercentageToUserBonuses { get; set; }
}
