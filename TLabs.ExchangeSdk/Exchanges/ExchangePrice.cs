using System;

namespace TLabs.ExchangeSdk.Exchanges
{
    public class ExchangePrice
    {
        public Guid Id { get; set; }
        public string CurrencyPairCode { get; set; }
        public bool IsBid { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithMarkup { get; set; }
        public decimal PriceWithMarkupAndFee { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset DateExpire { get; set; }
    }
}
