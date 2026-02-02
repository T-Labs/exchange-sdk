using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public enum StakingLockAction
    { Stake = 0, Unstake = 10 };

    public class StakingLockDto
    {
        public StakingLockAction Action { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string BlockchainTxId { get; set; }

        public override string ToString()
            => $"{nameof(StakingLockDto)}({Amount} {CurrencyCode}, action:{Action}, " +
            $"userId:{UserId}, BlockchainTxId: {BlockchainTxId})";
    }
}
