using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Currencies
{
    public class CurrenciesCache
    {
        private readonly ILogger _logger;

        private List<Currency> _currencies = new();
        private List<CurrencyPair> _currencyPairs = new();
        private List<Adapter> _adapters = new();
        private List<P2PExchangeCurrency> _p2PExchangeCurrencies = new();

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
                return _currencyPairs
                    .Where(_ => _.IsShowedForUsers
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

        public List<Adapter> GetAdapters(bool onlyAvailable = true)
        {
            if (onlyAvailable)
            {
                var currencyCodes = _currencies.Select(_ => _.Code).ToHashSet();
                return _adapters
                    .Where(_ => _.MainCurrencyCode == null || currencyCodes.Contains(_.MainCurrencyCode))
                    .ToList();
            }

            return _adapters;
        }

        public P2PExchangeCurrency GetP2PExchangeCurrency(string currencyCode)
        {
            return _p2PExchangeCurrencies.FirstOrDefault(_ => _.CurrencyCode == currencyCode);
        }

        public List<P2PExchangeCurrency> GetP2PExchangeCurrencies()
        {
            return _p2PExchangeCurrencies;
        }

        [Obsolete("Use GetAdapterIds()")]
        public string GetAdapterId(string currencyCode) => GetAdapterIds(currencyCode).FirstOrDefault();

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

        private async Task<CurrenciesInfo> LoadCurrenciesInfo(bool includeExchangeCurrencies = true,
            bool includeP2pExternalCurrencies = false)
        {
            var result = await $"depository/currencies/info".InternalApi()
                .SetQueryParam("includeExchangeCurrencies", includeExchangeCurrencies)
                .SetQueryParam("includeP2pExternalCurrencies", includeP2pExternalCurrencies)
                .GetJsonAsync<CurrenciesInfo>().GetQueryResult();
            return result.Data;
        }

        private async Task<List<P2PExchangeCurrency>> LoadP2PExchangeCurrencies()
        {
            var result = await $"depository/p2p-exchange-currencies".InternalApi()
                .GetJsonAsync<List<P2PExchangeCurrency>>().GetQueryResult();
            return result.Data;
        }

        public async Task LoadData(int countAttempts = 0, bool includeExchangeCurrencies = true,
            bool includeP2PCurrencies = false)
        {
            var currencies = await LoadCurrenciesInfo(includeExchangeCurrencies, includeP2PCurrencies);
            SetCurrenciesInfo(currencies);

            if (includeP2PCurrencies)
                _p2PExchangeCurrencies = await LoadP2PExchangeCurrencies();

            if (!IsLoaded)
            {
                var maxDelay =
                    TimeSpan.FromMinutes(10); // currencies are vital for most services, no reason to wait too much
                await Task.Delay(TimeHelper.GetDelay(countAttempts, maxDelay)); // use increasing delay and try again
                _ = LoadData(++countAttempts, includeExchangeCurrencies, includeP2PCurrencies);
            }
        }

        #endregion Load methods
    }
}
