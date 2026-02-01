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
    };
}
