using System;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Trading
{
    public class CurrencyPairData
    {
        public CurrencyPair CurrencyPair { get; set; }
        public decimal? Price { get; set; }
        public decimal? Price24hAgo { get; set; }
        public decimal PriceChangePercentage24h { get; set; }
        public decimal Volume24h { get; set; }
        public decimal? Low24h { get; set; }
        public decimal? High24h { get; set; }
        public DateTimeOffset? FirstTradeDate { get; set; }
    }
}
