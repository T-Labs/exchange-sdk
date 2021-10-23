using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.CurrencyOfferings
{
    public class CurrencyOffering
    {
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }

        /// <summary>User that receives profits for selling tokens</summary>
        public string AdminUserId { get; set; }

        public string Website { get; set; }
        public decimal TotalVolume { get; set; }
        public decimal HardCap { get; set; }
        public decimal SoftCap { get; set; }

        /// <summary>List of currencies from which users can buy this token</summary>
        public string CurrenciesForSale { get; set; } = "";

        public decimal PriceUsdt { get; set; } = 0;
        public decimal MinBuyAmount { get; set; }

        public string Status =>
            DateStart > DateTimeOffset.UtcNow ? "Planned" : DateEnd < DateTimeOffset.UtcNow ? "Ended" : "Active";

        public override string ToString() => $"{nameof(CurrencyOffering)}({Name}, {DateStart} - {DateEnd}, " +
            $"AdminUserId:{AdminUserId}, CurrenciesForSale:{CurrenciesForSale}, PriceUsdt:{PriceUsdt})";
    }
}