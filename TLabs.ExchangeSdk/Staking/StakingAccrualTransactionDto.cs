using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingAccrualTransactionDto
    {
        public string UserId { get; set; }
        public string BaseCurrencyCode { get; set; }
        public string AccrualCurrencyCode { get; set; }

        /// <summary>
        /// How much of AccrualCurrency is deposited to user
        /// </summary>
        public decimal AccrualAmount { get; set; }

        /// <summary>
        /// How much of AccrualCurrency is deposited to user (in USDT equivalent)
        /// </summary>
        public decimal AccrualAmountInUsdt { get; set; }

        /// <summary>
        /// User balance at the time of creation
        /// </summary>
        public decimal UserBalance { get; set; }

        /// <summary>
        /// User balance in USDT equivalent
        /// </summary>
        public decimal UserBalanceInUsdt { get; set; }

        public DateTimeOffset DatePlanned { get; set; }

        public DateTimeOffset? DateSentToDepository { get; set; }

        public bool IsSentToDepository => DateSentToDepository.HasValue;
    }
}
