using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Users
{
    public class UserFinancesSetting
    {
        [Key]
        public string UserId { get; set; }

        /// <summary>
        /// Take commission for Refill & Withdrawal in SRNT equivalent
        /// </summary>
        public bool UseSrntForRefillWithdraw { get; set; } = false;

        /// <summary>
        /// Take commission for Trades in SRNT equivalent
        /// </summary>
        public bool UseSrntForTrade { get; set; } = false;
    }
}
