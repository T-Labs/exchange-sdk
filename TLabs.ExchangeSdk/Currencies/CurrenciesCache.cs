using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.DotnetHelpers.Helpers;

namespace TLabs.ExchangeSdk.Currencies
{
    public class CurrenciesCache
    {
        private readonly ILogger _logger;

        private List<Currency> _currencies = new();
        private List<CurrencyPair> _currencyPairs = new();
        private List<Adapter> _adapters = new();

        /// <summary>
        /// Use for rounding commissions, quote amounts, deposits, withdrawals
        /// </summary>
        public const int Digits = 8;

        public CurrenciesCache(
            ILogger<CurrenciesCache> logger)
        {
            _logger = logger;
        }

        #region Getters

        public bool IsLoaded => _currencies?.Count > 0 && _currencyPairs?.Count > 0;

        public List<CurrencyPair> GetCurrencyPairs(bool onlyVisible = false)
        {
            if (onlyVisible)
            {
                return _currencyPairs.Where(_ => _.IsShowedForUsers
                    && _.CurrencyFrom.IsShowedForUsers && _.CurrencyTo.IsShowedForUsers)
                    .ToList();
            }
            return _currencyPairs;
        }

        public CurrencyPair GetCurrencyPair(string code)
        {
            var pair = _currencyPairs.FirstOrDefault(_ => _.Code == code);
            if (pair == null)
                _logger.LogError($"CurrenciesCache not found {code}");
            return pair;
        }

        public List<Currency> GetCurrencies(bool onlyVisible = false)
        {
            if (onlyVisible)
                return _currencies.Where(_ => _.IsShowedForUsers).ToList();
            return _currencies;
        }

        /// <summary>Get currencies with their own crypto-adapters (exclude tokens and fiat)</summary>
        public List<Currency> GetCryptoAdapterCurrencies() =>
            _currencies.Where(_ => _.TokenOf.NotHasValue() && !_.IsFiat).ToList();

        public Currency GetCurrency(string code)
        {
            var currency = _currencies.FirstOrDefault(_ => _.Code == code);
            if (currency == null)
                _logger.LogError($"CurrenciesCache not found {code}");
            return currency;
        }
        public List<Adapter> GetAdapters() => _adapters;

        [Obsolete("Use GetAdapterIds()")]
        public string GetAdapterId(string currencyCode) =>
            GetAdapterIds(currencyCode).FirstOrDefault();

        public List<string> GetAdapterIds(string currencyCode) =>
            GetCurrency(currencyCode).CurrencyAdapters.Select(_ => _.AdapterCode).ToList();

        public int GetBalanceDigits(string currencyCode) => GetCurrency(currencyCode).Digits;

        public int GetPriceDigits(string currencyPairCode) => GetCurrencyPair(currencyPairCode).DigitsPrice;

        public int GetAmountDigits(string currencyPairCode) => GetCurrencyPair(currencyPairCode).DigitsAmount;

        #endregion Getters


        #region Load methods

        public void SetCurrenciesInfo(CurrenciesInfo currenciesInfo)
        {
            if (currenciesInfo == null)
                return;
            _currencies = currenciesInfo.Currencies;
            _currencyPairs = currenciesInfo.CurrencyPairs;
            _adapters = currenciesInfo.Adapters;
        }

        private async Task<CurrenciesInfo> LoadCurrenciesInfo()
        {
            var result = await $"depository/currencies/info".InternalApi()
                .GetJsonAsync<CurrenciesInfo>().GetQueryResult();
            return result.Data;
        }

        public async Task LoadData(int countAttempts = 0)
        {
            var currencies = await LoadCurrenciesInfo();
            SetCurrenciesInfo(currencies);

            if (!IsLoaded)
            {
                var maxDelay = TimeSpan.FromMinutes(10); // currencies are vital for most services, no reason to wait too much
                await Task.Delay(TimeHelper.GetDelay(countAttempts, maxDelay)); // use increasing delay and try again
                _ = LoadData(++countAttempts);
            }
        }

        #endregion Load methods
    }
}
