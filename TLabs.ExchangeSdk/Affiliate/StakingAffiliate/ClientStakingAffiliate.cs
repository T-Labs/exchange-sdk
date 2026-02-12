using Flurl.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class ClientStakingAffiliate
    {
        private const string BaseUrl = "affiliate/staking-affiliate";

        private readonly ILogger _logger;

        public ClientStakingAffiliate(
            ILogger<ClientStakingAffiliate> logger)
        {
            _logger = logger;
        }

        public async Task<List<StakingAffiliateLevelConfig>> GetLevels()
        {
            var result = await $"{BaseUrl}/levels".InternalApi()
                .GetJsonAsync<List<StakingAffiliateLevelConfig>>();
            return result;
        }

        public async Task<StakingAffiliateUserDto> GetUser(string userId)
        {
            var result = await $"{BaseUrl}/users/{userId}".InternalApi()
                .GetJsonAsync<StakingAffiliateUserDto>();
            return result;
        }

        public async Task<List<StakingDirectReferralDto>> GetDirectReferrals(string userId)
        {
            var result = await $"{BaseUrl}/direct-referrals/{userId}".InternalApi()
                .GetJsonAsync<List<StakingDirectReferralDto>>();
            return result;
        }

        public async Task<PagedList<StakingAffiliateAccrualDto>> GetAccruals(string userId,
            int pageNumber = 1, int pageSize = 20)
        {
            var result = await $"{BaseUrl}/accruals/{userId}".InternalApi()
                .SetQueryParam(nameof(pageNumber), pageNumber)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<StakingAffiliateAccrualDto>>();
            return result;
        }

        public async Task<List<StakingAffiliateAccrualsTotalDto>> GetAccrualsTotal(string userId)
        {
            var result = await $"{BaseUrl}/accruals-total/{userId}".InternalApi()
                .GetJsonAsync<List<StakingAffiliateAccrualsTotalDto>>();
            return result;
        }
    }
}
