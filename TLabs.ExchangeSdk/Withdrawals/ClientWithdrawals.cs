using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.CryptoAdapters;

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

        public async Task<Withdrawal> GetWithdrawalByTransactionId(Guid transactionId)
        {
            var result = await $"{baseUrl}/by-transaction-id/{transactionId}".InternalApi()
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

        public virtual async Task<PagedList<Withdrawal>> GetPagedList(int page, int pageSize)
        {
            var result = await $"withdrawals/withdrawal/paginated-list".InternalApi()
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<Withdrawal>>()
                .GetQueryResult();

            return result.Succeeded ? result.Data : new PagedList<Withdrawal>();
        }
    }
}
