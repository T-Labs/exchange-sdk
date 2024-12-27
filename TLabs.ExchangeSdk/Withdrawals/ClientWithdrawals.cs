using Flurl.Http;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.CryptoAdapters;
using TLabs.ExchangeSdk.Verification;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class ClientWithdrawals
    {
        private const string baseUrl = "withdrawals/withdrawal";

        public async Task<List<Withdrawal>> GetWithdrawals(int? statusId = null, WithdrawalType? withdrawalType = null,
            string currencyCode = null, string userId = null, string publicId = null)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(statusId), statusId)
                .SetQueryParam(nameof(withdrawalType), withdrawalType)
                .SetQueryParam(nameof(currencyCode), currencyCode?.Trim().NullIfEmpty())
                .SetQueryParam(nameof(userId), userId?.Trim().NullIfEmpty())
                .SetQueryParam(nameof(publicId), publicId?.Trim().NullIfEmpty())
                .GetJsonAsync<List<Withdrawal>>();
            return result;
        }

        public async Task<Withdrawal> GetWithdrawal(Guid id)
        {
            var result = await $"{baseUrl}/{id}".InternalApi()
                .GetJsonAsync<Withdrawal>();
            return result;
        }

        public async Task<IFlurlResponse> ApproveWithdrawal(Guid id, bool allowErrorStatus = false)
        {
            var result = await $"{baseUrl}/approve/{id}/{allowErrorStatus}".InternalApi()
                .PostAsync();
            return result;
        }

        public async Task<IFlurlResponse> FinishWithdrawal(WithdrawalAdapterConfirmation dto)
        {
            var result = await $"{baseUrl}/finish".InternalApi()
                .PostJsonAsync(dto);
            return result;
        }

        public async Task<IFlurlResponse> CancelWithdrawal(Guid id)
        {
            var result = await $"{baseUrl}/{id}".InternalApi()
                .DeleteAsync();
            return result;
        }

        public async Task<string> GetParameter(string key)
        {
            var result = await $"withdrawals/parameters".InternalApi()
                .SetQueryParam(nameof(key), key)
                .GetStringAsync();
            return result;
        }

        public async Task<IFlurlResponse> UpdateParameter<T>(string key, T value)
        {
            var result = await $"withdrawals/parameters".InternalApi()
                .SetQueryParam(nameof(key), key)
                .PostJsonAsync(value.ToString());
            return result;
        }
    }
}
