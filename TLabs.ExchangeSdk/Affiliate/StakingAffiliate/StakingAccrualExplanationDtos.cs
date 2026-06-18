using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    /// <summary>One referral's contribution to the staking referral bonus over a period.</summary>
    public class StakingAccrualBreakdownItemDto
    {
        public string FromUserId { get; set; }
        public string FromUserNickname { get; set; }
        public string CurrencyCode { get; set; }

        /// <summary>Total accrual received from this referral in the period (bonus + non-bonus parts).</summary>
        public decimal Amount { get; set; }

        /// <summary>Accrual received from this referral in the period (only non-bonus part).</summary>
        public decimal AmountToMainAccount { get; set; }

        public string ReceiverLevel { get; set; }
        public decimal? AppliedPercentage { get; set; }
    }

    /// <summary>"What the sum is made of": per-referral breakdown of staking referral bonus for a period.</summary>
    public class StakingAccrualBreakdownDto
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
        public string CurrentLevel { get; set; }
        public List<StakingAccrualBreakdownItemDto> Items { get; set; } = new();
        public Dictionary<string, decimal> TotalsByCurrency { get; set; } = new();
    }

    /// <summary>Kind of concrete reason for a period-over-period change of the staking referral bonus.</summary>
    public enum StakingAccrualChangeReasonType
    {
        ReferralStopped = 10,
        ReferralReduced = 20,
        ReferralIncreased = 30,
        ReferralAdded = 40,
        LevelChanged = 50,
    }

    /// <summary>One concrete reason behind the change of the staking referral bonus.</summary>
    public class StakingAccrualChangeReasonDto
    {
        public StakingAccrualChangeReasonType Type { get; set; }
        public string FromUserId { get; set; }
        public string FromUserNickname { get; set; }
        public string CurrencyCode { get; set; }
        public decimal AmountDelta { get; set; }
        public string OldLevel { get; set; }
        public string NewLevel { get; set; }
        public string TriggeredByUserId { get; set; }
        public DateTimeOffset? Date { get; set; }
    }

    /// <summary>"Why the sum changed": comparison of a period against the immediately preceding one of equal length.</summary>
    public class StakingAccrualExplanationDto
    {
        public DateTimeOffset CurrentFrom { get; set; }
        public DateTimeOffset CurrentTo { get; set; }
        public DateTimeOffset PreviousFrom { get; set; }
        public DateTimeOffset PreviousTo { get; set; }
        public Dictionary<string, decimal> CurrentTotalsByCurrency { get; set; } = new();
        public Dictionary<string, decimal> PreviousTotalsByCurrency { get; set; } = new();
        public Dictionary<string, decimal> DeltaByCurrency { get; set; } = new();
        public List<StakingAccrualChangeReasonDto> Reasons { get; set; } = new();
    }
}
