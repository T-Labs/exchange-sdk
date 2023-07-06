using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TLabs.ExchangeSdk.Withdrawals
{
    /// <summary>Used in ColdWallet transfers</summary>
    public class CriticalBalanceValue
    {
        [Key]
        public string CurrencyCode { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
