using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TLabs.ExchangeSdk.Staking
{
    /// <summary>
    /// How staking rewards are accrued for a setting / stake.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StakingAccrualSchedule
    {
        /// <summary>One accrual slot per calendar day (legacy behaviour).</summary>
        Daily = 0,

        /// <summary>Single payout at end of lock (principal * APR * days / 365).</summary>
        AtMaturity = 1,
    }
}
