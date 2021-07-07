using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        public async Task<string> GetWalletAddress(string currencyCode, string userId,
            ClientType clientType = ClientType.User)
        {
            string adapterId = _currenciesCache.GetAdapterId(currencyCode);
            var result = await $"{adapterId}/address/{userId}".InternalApi()
                .SetQueryParam(nameof(clientType), clientType)
                .GetStringAsync();
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

        public async Task<TronParamsDto> TronGetParams() =>
            await $"trx/parameters".InternalApi().GetJsonAsync<TronParamsDto>();

        public async Task<TronParamsDto> TronSaveParams(TronParamsDto dto) =>
            await $"trx/parameters".InternalApi().PostJsonAsync<TronParamsDto>(dto);
    }
}
