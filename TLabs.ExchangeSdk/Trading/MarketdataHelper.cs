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
        /// <param name="quotes">preloaded dict with quotes</param>
        /// <param name="equivalentCurrency">BTC or USDT</param>
        public static decimal? CalculateEquivalent(this decimal amount, string currencyCode,
            Dictionary<string, Quote> quotes, string equivalentCurrency = "USDT")
        {
            var rate = GetQuoteRate(currencyCode, quotes, equivalentCurrency);
            return rate == null ? null : (amount * rate.Value).RoundDown(CurrenciesCache.Digits);
        }

        /// <summary>Calculate amount in currencyCode from its equivalent in USDT or BTC</summary>
        /// <param name="quotes">preloaded dict with quotes</param>
        /// <param name="equivalentCurrency">BTC or USDT</param>
        public static decimal? CalculateFromEquivalent(this decimal amount, string currencyCode,
            Dictionary<string, Quote> quotes, string equivalentCurrency = "USDT")
        {
            var rate = GetQuoteRate(currencyCode, quotes, equivalentCurrency);
            return rate == null ? null : (amount / rate.Value).RoundDown(CurrenciesCache.Digits);
        }

        public static decimal? GetQuoteRate(string currencyCode, Dictionary<string, Quote> quotes,
            string equivalentCurrency = "USDT")
        {
            var quote = quotes.GetValueOrDefault(currencyCode, null);
            decimal? rate = equivalentCurrency switch
            {
                "USDT" => quote?.UsdtRate,
                "BTC" => quote?.BtcRate,
                _ => null,
            };
            return rate;
        }

        /// <summary>
        /// someAmount * conversionRate: converts amount from currencyFrom to currencyTo
        /// </summary>
        /// <returns>conversionRate</returns>
        public static decimal? GetConversionRate(Dictionary<string, Quote> quotes, string currencyFrom, string currencyTo)
        {
            if (currencyFrom == currencyTo)
                return 1;
            var quoteFrom = quotes.GetValueOrDefault(currencyFrom, null);
            var quoteTo = quotes.GetValueOrDefault(currencyTo, null);
            if (quoteFrom?.UsdtRate == null || quoteTo?.UsdtRate == null || quoteTo?.UsdtRate == 0)
                return null;
            decimal conversionRate = quoteFrom.UsdtRate.Value / quoteTo.UsdtRate.Value;
            return conversionRate.RoundDown(CurrenciesCache.Digits);
        }

        /// <summary>
        /// Convert amounts in different currencies to currencyTo and get sum
        /// </summary>
        public static (decimal total, HashSet<string> skippedCurrencies) CalculateTotalEquivalent(Dictionary<string, Quote> quotes,
            Dictionary<string, decimal> amounts, string currencyTo)
        {
            HashSet<string> skippedCurrencies = new();
            decimal total = 0;
            foreach (var (currency, amount) in amounts)
            {
                decimal? conversionRate = GetConversionRate(quotes, currency, currencyTo);
                if (!conversionRate.HasValue)
                {
                    skippedCurrencies.Add(currency);
                    continue;
                }
                decimal amountConverted = amount * conversionRate.Value;
                total += amountConverted;
            }
            return (total, skippedCurrencies);
        }
    }
}
