using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Currencies
{
    public class CurrenciesKeeper
    {
        private readonly ILogger _logger;

        protected List<Currency> _currencies = new List<Currency>();
        protected List<CurrencyPair> _currencyPairs = new List<CurrencyPair>();

        /// <summary>
        /// Use for rounding commissions, quote amounts, deposits, withdrawals
        /// </summary>
        public const int Digits = 8;

        public CurrenciesKeeper(
            ILogger<CurrenciesKeeper> logger)
        {
            _logger = logger;
        }

        #region Getters

        public List<CurrencyPair> GetCurrencyPairs() => _currencyPairs;

        public CurrencyPair GetCurrencyPair(string code)
        {
            var pair = _currencyPairs.FirstOrDefault(_ => _.Code == code);
            if (pair == null)
                _logger.LogWarning($"GetCurrencyPair() {code} wasn't found");
            return pair;
        }

        public List<Currency> GetCurrencies() => _currencies;

        public Currency GetCurrency(string code)
        {
            var currency = _currencies.FirstOrDefault(_ => _.Code == code);
            if (currency == null)
                _logger.LogWarning($"GetCurrency() {code} wasn't found");
            return currency;
        }

        public string GetAdapterId(string currencyCode) => GetCurrency(currencyCode).CryptoAdapterId;

        public int GetBalanceDigits(string currencyCode) => GetCurrency(currencyCode).Digits;

        public int GetPriceDigits(string currencyPairCode) => GetCurrencyPair(currencyPairCode).DigitsPrice;

        public int GetAmountDigits(string currencyPairCode) => GetCurrencyPair(currencyPairCode).DigitsAmount;

        #endregion Getters


        #region Load methods

        public void SetCurrencies(List<Currency> currencies)
        {
            if (currencies != null)
                _currencies = currencies;
        }

        public void SetCurrencyPairs(List<CurrencyPair> currencyPairs)
        {
            if (currencyPairs != null)
                _currencyPairs = currencyPairs;
        }

        private async Task<List<CurrencyPair>> LoadCurrencyPairs()
        {
            var result = await $"depository/currency-pairs".InternalApi()
                .GetJsonAsync<List<CurrencyPair>>().GetQueryResult();
            return result.Data;
        }

        private async Task<List<Currency>> LoadCurrencies()
        {
            var result = await $"depository/currencies".InternalApi()
                .GetJsonAsync<List<Currency>>().GetQueryResult();
            return result.Data;
        }

        public async Task LoadData()
        {
            SetCurrencyPairs(await LoadCurrencyPairs());
            SetCurrencies(await LoadCurrencies());
        }

        #endregion Load methods
    }
}
