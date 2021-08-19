using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Trading
{
    public static class MarketdataHelper
    {

        /// <summary>Calculate equivalent of amount</summary>
        /// <param name="quotesDict">preloaded dict with quotes</param>
        /// <param name="equivalentCurrency">BTC or USDT</param>
        public static decimal? CalculateEquivalent(this decimal amount, string currencyCode,
            Dictionary<string, Quote> quotesDict, string equivalentCurrency = "USDT")
        {
            var rate = GetQuoteRate(currencyCode, quotesDict, equivalentCurrency);
            return rate == null ? null : (amount * rate.Value).RoundDown(CurrenciesCache.Digits);
        }

        /// <summary>Calculate amount in currencyCode from its equivalent in USDT or BTC</summary>
        /// <param name="quotesDict">preloaded dict with quotes</param>
        /// <param name="equivalentCurrency">BTC or USDT</param>
        public static decimal? CalculateFromEquivalent(this decimal amount, string currencyCode,
            Dictionary<string, Quote> quotesDict, string equivalentCurrency = "USDT")
        {
            var rate = GetQuoteRate(currencyCode, quotesDict, equivalentCurrency);
            return rate == null ? null : (amount / rate.Value).RoundDown(CurrenciesCache.Digits);
        }

        public static decimal? GetQuoteRate(string currencyCode, Dictionary<string, Quote> quotesDict,
            string equivalentCurrency = "USDT")
        {
            var quote = quotesDict.GetValueOrDefault(currencyCode, null);
            decimal? rate = equivalentCurrency switch
            {
                "USDT" => quote?.UsdtRate,
                "BTC" => quote?.BtcRate,
                _ => null,
            };
            return rate;
        }
    }
}
