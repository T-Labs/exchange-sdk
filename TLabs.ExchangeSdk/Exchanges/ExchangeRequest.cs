using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Exchanges
{
    public class ExchangeRequest
    {
        /// <summary>Guid for exchange and order objects (optional)</summary>
        public Guid ActionId { get; set; }

        [Required]
        public string CurrencyPairCode { get; set; }

        public bool IsBid { get; set; }

        /// <summary>Order amount in base currency</summary>
        public decimal Amount { get; set; }

        /// <summary>Guid of estimated price object</summary>
        [Required]
        public Guid EstimatedPriceId { get; set; }

        public string UserId { get; set; }

        public bool ExchangePriceFits(ExchangePrice priceObj)
        {
            return UserId == priceObj.UserId // same user
                && CurrencyPairCode == priceObj.CurrencyPairCode && IsBid == priceObj.IsBid // same orderbook
                && priceObj.Price > 0;
        }
    }
}
