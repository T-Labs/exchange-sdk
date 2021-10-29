using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CurrencyOfferings
{
    public class CurrencyOffering
    {
        public string CurrencyCode { get; set; }
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

        /// <summary>How much tokens percentage will be paid initially</summary>
        public decimal PaymentInitialPercentage { get; set; } = 50;

        /// <summary>How many days it will take to pay the rest</summary>
        public decimal DaysToPayRest { get; set; } = 10;

        /// <summary>How much of admin profit goes to system (0-100)</summary>
        public decimal SystemFeePercentage { get; set; } = 0;

        public string Status =>
            DateStart > DateTimeOffset.UtcNow ? "Planned" : DateEnd < DateTimeOffset.UtcNow ? "Ended" : "Active";

        public override string ToString() => $"{nameof(CurrencyOffering)}({CurrencyCode}, Name:{Name}, {DateStart} - {DateEnd}, " +
            $"AdminUserId:{AdminUserId}, CurrenciesForSale:{CurrenciesForSale}, PriceUsdt:{PriceUsdt})";

        public void Trim()
        {
            CurrencyCode = CurrencyCode?.Trim().NullIfEmpty();
            Name = Name?.Trim().NullIfEmpty();
            AdminUserId = AdminUserId?.Trim().NullIfEmpty();
            Website = Website?.Trim().NullIfEmpty();
        }
    }
}
