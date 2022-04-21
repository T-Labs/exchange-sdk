using System;
using System.Linq;

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
}
