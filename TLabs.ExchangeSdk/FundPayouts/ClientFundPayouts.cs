using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.FundPayouts.Dtos;

namespace TLabs.ExchangeSdk.FundPayouts
{
    /// <summary>Client for fund payout endpoints exposed by stock-withdrawals.</summary>
    public class ClientFundPayouts
    {
        private const string baseUrl = "withdrawals/fund-payouts";

        public async Task<List<PayoutFundDto>> GetFunds()
        {
            return await $"{baseUrl}/funds".InternalApi()
                .GetJsonAsync<List<PayoutFundDto>>();
        }

        public async Task<FundPayoutSettingsDto> GetSettings(string fundCode)
        {
            return await $"{baseUrl}/settings/{fundCode}".InternalApi()
                .GetJsonAsync<FundPayoutSettingsDto>();
        }

        public async Task<QueryResult> SaveSettings(FundPayoutSettingsDto settings)
        {
            return await $"{baseUrl}/settings/{settings.FundCode}".InternalApi()
                .PostJsonAsync(settings)
                .GetQueryResult();
        }

        public async Task<List<FundPayoutRecipientDto>> GetRecipients(string fundCode)
        {
            return await $"{baseUrl}/recipients".InternalApi()
                .SetQueryParam(nameof(fundCode), fundCode)
                .GetJsonAsync<List<FundPayoutRecipientDto>>();
        }

        public async Task<List<FundPayoutAddressDto>> GetAddresses(string fundCode, string userId = null)
        {
            return await $"{baseUrl}/addresses".InternalApi()
                .SetQueryParam(nameof(fundCode), fundCode)
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<List<FundPayoutAddressDto>>();
        }

        public async Task<QueryResult> AddAddress(AddFundPayoutAddressDto address)
        {
            return await $"{baseUrl}/addresses".InternalApi()
                .PostJsonAsync(address)
                .GetQueryResult();
        }

        public async Task<QueryResult> DeleteAddress(Guid addressId)
        {
            return await $"{baseUrl}/addresses/{addressId}".InternalApi()
                .DeleteAsync()
                .GetQueryResult();
        }

        /// <summary>Reserve in the fund and send on-chain. Returns the withdrawal Id.</summary>
        public async Task<QueryResult<Guid>> CreatePayout(CreateFundPayoutRequest request)
        {
            return await $"{baseUrl}/payouts".InternalApi()
                .PostJsonAsync<Guid>(request)
                .GetQueryResult();
        }

        public async Task<PagedList<FundPayoutDto>> GetPayouts(string fundCode, string userId = null,
            int page = 1, int pageSize = 25)
        {
            return await $"{baseUrl}/payouts".InternalApi()
                .SetQueryParam(nameof(fundCode), fundCode)
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<FundPayoutDto>>();
        }

        /// <summary>Return a reserve stuck after a failed send (payout in Error status).</summary>
        public async Task<QueryResult> CancelReserve(Guid payoutId)
        {
            return await $"{baseUrl}/payouts/{payoutId}/cancel-reserve".InternalApi()
                .PostAsync()
                .GetQueryResult();
        }
    }
}
