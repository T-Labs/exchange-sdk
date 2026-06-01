using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
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

        public virtual async Task<Dictionary<string, MetricsDto>> GetMetrics(
            IReadOnlyCollection<string> userIds)
        {
            return await $"{BaseUrl}/metrics".InternalApi()
                .PostJsonAsync<Dictionary<string, MetricsDto>>(userIds);
        }

        public async Task<List<string>> GetDescendantUserIds(string userId)
        {
            var result = await $"{BaseUrl}/descendants/{userId}".InternalApi()
                .GetJsonAsync<List<string>>();
            return result ?? new List<string>();
        }

        public virtual async Task<Dictionary<string, List<string>>> GetDescendantUserIds(IReadOnlyCollection<string> userIds)
        {
            return await $"{BaseUrl}/descendants".InternalApi()
                .PostJsonAsync<Dictionary<string, List<string>>>(userIds);
        }

        /// <param name="referralsDepth">Referral depth: 1 = direct referrals, 2 = referrals of direct referrals, null = all levels</param>
        public async Task<List<StakingDirectReferralDto>> GetReferrals(string userId, int? referralsDepth = null,
            bool includeReferralCounts = false)
        {
            var request = $"{BaseUrl}/referrals/{userId}".InternalApi()
                .SetQueryParam(nameof(includeReferralCounts), includeReferralCounts);
            if (referralsDepth.HasValue)
                request = request.SetQueryParam(nameof(referralsDepth), referralsDepth.Value);
            var result = await request.GetJsonAsync<List<StakingDirectReferralDto>>();
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

        /// <summary>Paged users with staking affiliate metrics (admin).</summary>
        public async Task<PagedList<StakingAffiliateAdminUserRowDto>> GetAdminUsersPageAsync(
            int pageNumber, int pageSize, string search = null)
        {
            var request = $"{BaseUrl}/admin/users".InternalApi()
                .SetQueryParam(nameof(pageNumber), pageNumber)
                .SetQueryParam(nameof(pageSize), pageSize);
            if (!string.IsNullOrWhiteSpace(search))
                request = request.SetQueryParam(nameof(search), search.Trim());
            return await request.GetJsonAsync<PagedList<StakingAffiliateAdminUserRowDto>>();
        }

        public async Task SetAdminUserLevelAsync(string userId, string level, int freezeDays)
        {
            await $"{BaseUrl}/admin/users/{userId}/levels".InternalApi()
                .PutJsonAsync(new SetStakingAffiliateLevelAdminDto
                {
                    Level = level,
                    FreezeDays = freezeDays,
                });
        }
    }
}
