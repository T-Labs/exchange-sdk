using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Commissions
{
    public class Commission
    {
        public Guid CommissionId { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public decimal Percent { get; set; }

        public decimal Minimum { get; set; }

        /// <summary>CurrencyCode if commission is in other currency</summary>
        public string CommissionCurrencyCode { get; set; }

        public string CommissionTypeCode { get; set; }

        public virtual CommissionType CommissionType { get; set; }
    }
}
