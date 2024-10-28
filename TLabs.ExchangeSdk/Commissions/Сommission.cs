using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Commissions
{
    public class Commission
    {
        [Key]
        public Guid CommissionId { get; set; }

        public string CurrencyCode { get; set; }

        /// <summary>P2P deals use CurrencyPair instead of Currency</summary>
        public string CurrencyPairCode { get; set; }

        /// <summary>
        /// Different adapters (eth, tron, advcash, etc) can have
        /// different deposit and withdrawal commissions
        /// Null for IsFiat currencies and for DealBid\DealAsk types
        /// </summary>
        public string CurrencyAdapterCode { get; set; }

        /// <summary>Commission percent</summary>
        public decimal Percent { get; set; }

        /// <summary>Minimum commission</summary>
        public decimal Minimum { get; set; }

        /// <summary>CurrencyCode if commission is in other currency</summary>
        public string CommissionCurrencyCode { get; set; }

        [Required]
        public string CommissionTypeCode { get; set; }

        public virtual CommissionType CommissionType { get; set; }

        public string HashCode =>
            GetHashCode(CommissionTypeCode, CurrencyCode ?? CurrencyPairCode, CurrencyAdapterCode);

        public static string GetHashCode(string typeCode, string currencyOrPairCode, string adapterCode) =>
            $"{typeCode}_{currencyOrPairCode}_{adapterCode}";
    }
}
