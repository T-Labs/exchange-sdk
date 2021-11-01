using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.CurrencyOfferings
{
    public enum CurrencyOfferingPurchaseStatus { Created = 0, Paid = 10, FullyUnblocked = 20, Error = 50, };

    public class CurrencyOfferingPurchase
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public CurrencyOfferingPurchaseStatus Status { get; set; } = CurrencyOfferingPurchaseStatus.Created;

        public string UserId { get; set; }

        /// <summary>CurrencyOffering Code</summary>
        public string CurrencyCode { get; set; }

        public string PayingCurrencyCode { get; set; }

        /// <summary>Amount in CurrencyOffering currency</summary>
        public decimal BuyAmount { get; set; }

        public decimal Price { get; set; }

        public decimal PayAmount() => (BuyAmount * Price).RoundDown(CurrenciesCache.Digits);

        public override string ToString() => $"{nameof(CurrencyOfferingPurchase)}" +
            $"({Status}, {BuyAmount} {CurrencyCode} for {PayAmount()} {PayingCurrencyCode}, Price:{Price})";
    }
}
