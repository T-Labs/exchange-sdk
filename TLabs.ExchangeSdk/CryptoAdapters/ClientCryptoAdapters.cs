using Flurl.Http;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class ClientCryptoAdapters
    {
        private readonly CurrenciesCache _currenciesCache;

        public ClientCryptoAdapters(
            CurrenciesCache currenciesCache)
        {
            _currenciesCache = currenciesCache;
        }

        public async Task<AddressModel> GetWalletAddress(string currencyCode, string userId,
            ClientType clientType = ClientType.User)
        {
            string adapterId = _currenciesCache.GetAdapterId(currencyCode);
            var result = await $"{adapterId}/address".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(clientType), clientType)
                .GetJsonAsync<AddressModel>();
            return result;
        }

        public async Task<AdapterInfo> GetAdapterInfo(string mainCurrencyCode)
        {
            string adapterId = _currenciesCache.GetAdapterId(mainCurrencyCode);
            var cancelToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
            var result = await $"{adapterId}/adapter-info".InternalApi()
                .GetJsonAsync<AdapterInfo>(cancelToken);
            return result;
        }

        public async Task<decimal> GetDepositMinAmount(string currencyCode)
        {
            string adapterId = _currenciesCache.GetAdapterId(currencyCode);
            string resultStr = await $"{adapterId}/refill-min-amount/{currencyCode}".InternalApi()
                .GetStringAsync();
            decimal result = Convert.ToDecimal(resultStr);
            return result;
        }

        #region ETH

        public async Task<QueryResult<string>> ResendTransaction(string currencyCode, string txHash, decimal? newGasPrice = null)
        {
            string adapterId = _currenciesCache.GetAdapterId(currencyCode);
            string url = $"{adapterId}/transactions/resend/{txHash}" +
                $"?newGasPrice={newGasPrice?.ToString(CultureInfo.InvariantCulture)}";
            var result = await url.InternalApi().PostJsonAsync<string>(null).GetQueryResult();
            Console.WriteLine($"ResendTransaction txHash change: {txHash} -> {result.Data}  {result.ErrorsString}");
            return result;
        }

        public async Task<QueryResult<string>> CancelTransaction(string currencyCode, string txHash, decimal? newGasPrice = null)
        {
            string adapterId = _currenciesCache.GetAdapterId(currencyCode);
            var result = await $"{adapterId}/transactions/cancel/{txHash}?newGasPrice={newGasPrice}".InternalApi()
                .PostJsonAsync<string>(null).GetQueryResult();
            Console.WriteLine($"CancelTransaction txHash change: {txHash} -> {result.Data}  {result.ErrorsString}");
            return result;
        }

        #endregion ETH

        #region TRON

        public async Task<TronParamsDto> TronGetParams() =>
            await $"trx/parameters".InternalApi().GetJsonAsync<TronParamsDto>();

        public async Task<TronParamsDto> TronSaveParams(TronParamsDto dto) =>
            await $"trx/parameters".InternalApi().PostJsonAsync<TronParamsDto>(dto);

        #endregion TRON
    }
}
