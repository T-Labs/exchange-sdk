using System;
using TLabs.ExchangeSdk.RabbitMq;

namespace TLabs.ExchangeSdk.Affiliate
{
    /// <summary>Message sent when staking accrual is deposited to user</summary>
    public class AffiliateStakeAccrualMessage : Message
    {
        /// <summary>User who received the staking accrual</summary>
        public string UserId { get; set; }

        /// <summary>Unique identifier for this accrual (e.g., "{stakeId}_{date}_{hour}")</summary>
        public string AccrualActionId { get; set; }

        /// <summary>Accrual amount in original currency</summary>
        public decimal AccrualAmount { get; set; }

        /// <summary>Currency code of the accrual</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Accrual amount converted to USD at time of event</summary>
        public decimal AccrualAmountUsd { get; set; }

        /// <summary>Time when the accrual was generated</summary>
        public DateTimeOffset AccrualTime { get; set; }
    }
}
