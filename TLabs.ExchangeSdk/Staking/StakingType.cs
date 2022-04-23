using System;
using System.Linq;
using TLabs.ExchangeSdk.Depository;

namespace TLabs.ExchangeSdk.Staking
{
    public enum StakingType
    {
        /// <summary>
        /// Accrual amount depends on user balance
        /// </summary>
        Passive = 0,

        /// <summary>
        /// User locks a portion of his balance to get accruals
        /// </summary>
        Locked = 10,

        /// <summary>
        /// User locks a portion of his USDT balance for STEPN NFT project
        /// </summary>
        LockedForStepn = 20,
    };

    public static class StakingTypeExtensions
    {
        public static AccountChart GetAccountChartLocked(this StakingType type) => type switch
        {
            StakingType.Locked => AccountChart.StakingLocked,
            StakingType.LockedForStepn => AccountChart.StakingLockedForStepn,
            _ => throw new ArgumentException($"InvalidStakingType {type}"),
        };

        public static AccountChart GetAccountChartLockedWithdrawal(this StakingType type) => type switch
        {
            StakingType.Locked => AccountChart.StakingLockedWithdrawal,
            StakingType.LockedForStepn => AccountChart.StakingLockedForStepnWithdrawal,
            _ => throw new ArgumentException($"InvalidStakingType {type}"),
        };
    }
}
