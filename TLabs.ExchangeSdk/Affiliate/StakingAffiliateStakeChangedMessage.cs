using System;
using TLabs.ExchangeSdk.RabbitMq;

namespace TLabs.ExchangeSdk.Affiliate
{
    /// <summary>Message sent when user stake is created or released</summary>
    public class StakingAffiliateStakeChangedMessage : Message
    {
        /// <summary>User who created/released the stake</summary>
        public string UserId { get; set; }

        /// <summary>Stake identifier</summary>
        public Guid UserStakeId { get; set; }

        /// <summary>True if stake was created, false if released</summary>
        public bool IsStakeCreated { get; set; }

        /// <summary>Stake amount in original currency</summary>
        public decimal StakeAmountInCurrency { get; set; }

        /// <summary>Currency code of the stake</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Stake amount converted to USD at time of event</summary>
        public decimal StakeAmountUsd { get; set; }
    }
}
