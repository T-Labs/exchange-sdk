using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Trading
{
    public static class OrderHelper
    {
        public static decimal GetPrice(decimal amountBase, decimal amountQuote) =>
            amountQuote / amountBase;

        /// <summary>Find where base and quote amounts</summary>
        public static (T amountBase, T amountQuote) GetOrderAmountsFromDirection<T>(bool isBid, T amountFrom, T amountTo)
        {
            return isBid ? (amountTo, amountFrom) : (amountFrom, amountTo);
        }

        public static QueryResult<(CurrencyPair currencyPair, bool isBid)> GetCurrencyPairAndSide(
            List<CurrencyPair> currencyPairs, string currencyFrom, string currencyTo)
        {
            var currencyPair = currencyPairs.FirstOrDefault(_ =>
                (_.CurrencyToId == currencyTo && _.CurrencyFromId == currencyFrom) ||
                (_.CurrencyToId == currencyFrom && _.CurrencyFromId == currencyTo));
            if (currencyPair == null)
                return QueryResult<(CurrencyPair, bool)>.CreateFailedLogic("CurrencyPairNotFound");
            bool isBid = currencyPair.CurrencyFromId == currencyFrom;
            return QueryResult<(CurrencyPair, bool)>.CreateSucceeded((currencyPair, isBid));
        }

        /// <summary>Fill empty values in amountBase, amountQuote, price</summary>
        public static QueryResult<(decimal amountBase, decimal amountQuote, decimal price)> FillAmounts(
            CurrencyPair currencyPair, decimal? amountBase, decimal? amountQuote, decimal? price = null)
        {
            if (amountBase == 0) amountBase = null;
            if (amountQuote == 0) amountQuote = null;
            if (price == 0) price = null;

            if (amountBase == null && amountQuote == null)
                return QueryResult<(decimal, decimal, decimal)>.CreateFailedLogic("AmountNotSpecified");
            if (amountBase != null && amountQuote != null)
                price = GetPrice(amountBase.Value, amountQuote.Value).RoundDown(currencyPair.DigitsPrice);
            if (price == null) // price should be known by now
                return QueryResult<(decimal, decimal, decimal)>.CreateFailedLogic("PriceNotSpecified");

            if (amountBase == null)
                amountBase = (amountQuote.Value / price.Value).RoundDown(currencyPair.DigitsAmount);
            if (amountQuote == null)
                amountQuote = (amountBase.Value * price.Value).RoundDown(CurrenciesCache.Digits);

            return QueryResult<(decimal, decimal, decimal)>.CreateSucceeded((amountBase.Value,
                amountQuote.Value, price.Value));
        }

        public static QueryResult<OrderBase> GetOrder(CurrencyPair currencyPair, bool isBid,
            decimal? amountBaseNullable, decimal? amountQuoteNullable, decimal? priceNullable = null)
        {
            var amountsResult = FillAmounts(currencyPair, amountBaseNullable, amountQuoteNullable, priceNullable);
            if (!amountsResult.Succeeded)
                return QueryResult<OrderBase>.CreateFailedLogic(amountsResult.LogicError);
            var (amountBase, amountQuote, price) = amountsResult.Data;

            var order = new OrderBase(isBid, currencyPair.Code, price, amountBase);
            return QueryResult<OrderBase>.CreateSucceeded(order);
        }

        public static QueryResult<OrderBase> GetOrderFromDirection(CurrencyPair currencyPair, bool isBid,
            decimal? amountFrom, decimal? amountTo, decimal? price = null)
        {
            var (amountBase, amountQuote) = GetOrderAmountsFromDirection(isBid, amountFrom, amountTo);
            return GetOrder(currencyPair, isBid, amountBase, amountQuote, price);
        }

        /// <summary>
        /// Construct order from parameters
        /// amountFrom or amountTo is required
        /// price is required if amountFrom or amountTo is null
        /// </summary>
        /// <param name="currencyPairs"></param>
        /// <param name="currencyFrom">Currency that user sells (required)</param>
        /// <param name="currencyTo">Currency that user buys (required)</param>
        /// <param name="amountFrom">Amount of currencyFrom that user sells</param>
        /// <param name="amountTo">Amount of currencyTo that user buys</param>
        /// <param name="price">Order price</param>
        public static QueryResult<OrderBase> GetOrderFromDirection(List<CurrencyPair> currencyPairs,
            string currencyFrom, string currencyTo,
            decimal? amountFrom, decimal? amountTo, decimal? price = null)
        {
            var currencyPairResult = GetCurrencyPairAndSide(currencyPairs, currencyFrom, currencyTo);
            if (!currencyPairResult.Succeeded)
                return QueryResult<OrderBase>.CreateFailedLogic(currencyPairResult.LogicError);
            var (currencyPair, isBid) = currencyPairResult.Data;

            return GetOrderFromDirection(currencyPair, isBid, amountFrom, amountTo, price);
        }
    }
}
