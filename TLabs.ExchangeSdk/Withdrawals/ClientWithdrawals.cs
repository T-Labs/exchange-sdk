using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class ClientWithdrawals
    {
        private const string baseUrl = "withdrawals/withdrawal";

        public async Task<List<Withdrawal>> GetWithdrawals(int? statusId = null, WithdrawalType? withdrawalType = null,
            string currencyCode = null, string userId = null)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(statusId), statusId)
                .SetQueryParam(nameof(withdrawalType), withdrawalType)
                .SetQueryParam(nameof(currencyCode), currencyCode.NullIfEmpty())
                .SetQueryParam(nameof(userId), userId.NullIfEmpty())
                .GetJsonAsync<List<Withdrawal>>();
            return result;
        }

        public async Task<Withdrawal> GetWithdrawal(Guid id)
        {
            var result = await $"{baseUrl}/{id}".InternalApi()
                .GetJsonAsync<Withdrawal>();
            return result;
        }

        public async Task<IFlurlResponse> CancelWithdrawal(Guid id)
        {
            var result = await $"{baseUrl}/{id}".InternalApi()
                .DeleteAsync();
            return result;
        }
    }
}
