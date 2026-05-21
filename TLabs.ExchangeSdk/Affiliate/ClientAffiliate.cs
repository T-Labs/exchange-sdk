using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class ClientAffiliate
    {
        private readonly ILogger _logger;

        public ClientAffiliate(
            ILogger<ClientAffiliate> logger)
        {
            _logger = logger;
        }

        public async Task<List<ReferralUser>> GetUsersByIds(List<string> userIds)
        {
            var result = await $"affiliate/users/by-ids".InternalApi()
                .PostJsonAsync<List<ReferralUser>>(userIds);
            return result;
        }

        public async Task<ReferralUser> GetUser(string inviteCode)
        {
            var result = await $"affiliate/users/{inviteCode}".InternalApi()
                .GetJsonAsync<ReferralUser>();
            return result;
        }

        public async Task<AffiliateUserInfo> GetUserInfo(string userId)
        {
            var result = await $"affiliate/user-info/{userId}".InternalApi()
                .GetJsonAsync<AffiliateUserInfo>();
            return result;
        }

        public async Task<AmbassadorSettingsDto> GetAmbassadorSettings(string userId)
        {
            return await $"affiliate/ambassadors/{userId}".InternalApi()
                .GetJsonAsync<AmbassadorSettingsDto>();
        }

        public async Task SetAmbassadorSettings(string userId, AmbassadorSettingsDto dto)
        {
            await $"affiliate/ambassadors/{userId}".InternalApi()
                .PutJsonAsync(dto);
        }

        public async Task<List<AmbassadorReferralLinkDto>> GetAmbassadorLinks(string userId)
        {
            return await $"affiliate/ambassadors/{userId}/links".InternalApi()
                .GetJsonAsync<List<AmbassadorReferralLinkDto>>();
        }

        public async Task<AmbassadorReferralLinkDto> CreateAmbassadorLink(string userId, CreateAmbassadorReferralLinkRequest dto)
        {
            return await $"affiliate/ambassadors/{userId}/links".InternalApi()
                .PostJsonAsync<AmbassadorReferralLinkDto>(dto);
        }

        public async Task<decimal> GetCommissionDiscountPercent(string userId)
        {
            return await $"affiliate/ambassadors/{userId}/commission-discounts".InternalApi()
                .GetJsonAsync<decimal>();
        }

        public async Task<List<Profit>> GetProfits(List<Guid> ids)
        {
            var result = await $"affiliate/profits".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .PostJsonAsync<List<Profit>>(ids);
            return result;
        }

        public async Task<PagedList<AccrualDto>> GetAccruals(string userId, int pageNumber = 1, int pageSize = 20,
            string currencyCode = null, ProfitType? profitType = null,
            IReadOnlyList<ProfitType> profitTypes = null)
        {
            var request = $"affiliate/accruals".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(pageNumber), pageNumber)
                .SetQueryParam(nameof(pageSize), pageSize);

            if (currencyCode != null)
                request = request.SetQueryParam(nameof(currencyCode), currencyCode);

            // profitTypes (multi) overrides single profitType when non-empty — matches affiliate Api GetAccruals.
            if (profitTypes != null && profitTypes.Count > 0)
                request = request.SetQueryParam(nameof(profitTypes), profitTypes.Select(p => (int)p).ToList());
            else if (profitType != null)
                request = request.SetQueryParam(nameof(profitType), profitType);

            var result = await request.GetJsonAsync<PagedList<AccrualDto>>();
            return result;
        }

        public async Task<List<TotalAccrualsInfo>> GetTotalAccruals(string userId)
        {
            var result = await $"affiliate/total-accruals".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<List<TotalAccrualsInfo>>();
            return result;
        }

        public virtual async Task<List<string>> GetInvitedUserIds()
        {
            var response = await "affiliate/users/invited".InternalApi()
                .GetJsonAsync<List<string>>().GetQueryResult();

            return response.Succeeded ? response.Data : new List<string>();
        }

        public virtual async Task<AffiliateStatisticsDto> GetStatistics()
        {
            var response = await "affiliate/stat".InternalApi()
                .GetJsonAsync<AffiliateStatisticsDto>().GetQueryResult();

            return response.Succeeded ? response.Data : new AffiliateStatisticsDto();
        }

        public virtual async Task<int> GetInvitedCountForPeriod(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var response = await "affiliate/stat/invited-count"
                .InternalApi()
                .SetQueryParam(nameof(fromDate), fromDate.ToString("o"))
                .SetQueryParam(nameof(toDate), toDate.ToString("o"))
                .GetJsonAsync<int>()
                .GetQueryResult();

            return response.Succeeded ? response.Data : 0;
        }

        public virtual async Task<Dictionary<string, decimal>> GetAccrualsSummary(string userId,
            string currencyCode = null, ProfitType? profitType = null)
        {
            var result = await $"affiliate/accruals/summary/{userId}".InternalApi()
               .SetQueryParam("currencyCode", currencyCode)
               .SetQueryParam("profitType", profitType)
               .GetJsonAsync<Dictionary<string, decimal>>()
               .GetQueryResult();

            return result.Succeeded ? result.Data : new Dictionary<string, decimal>();
        }

        public virtual async Task<AccrualsFiltersResponse> GetAccrualsFilters(string userId)
        {
            var result = await $"affiliate/accruals/filters/{userId}".InternalApi()
                .GetJsonAsync<AccrualsFiltersResponse>()
                .GetQueryResult();

            return result.Succeeded ? result.Data : new AccrualsFiltersResponse();
        }

        public virtual async Task<List<AffiliateAccrualsGroupDto>> GetAccrualGroups(string userId,
            DateTimeOffset sinceDate, DateTimeOffset endDate, int maxLevel = 1)
        {
            var result = await $"affiliate/accrual-groups/{userId}".InternalApi()
                    .SetQueryParam("sinceDate", sinceDate.ToString("o"))
                    .SetQueryParam("endDate", endDate.ToString("o"))
                    .SetQueryParam("maxLevel", maxLevel)
                    .GetJsonAsync<List<AffiliateAccrualsGroupDto>>()
                    .GetQueryResult();

            return result.Succeeded ? result.Data : new List<AffiliateAccrualsGroupDto>();
        }

        public virtual async Task<QueryResult> Rebind(string referralUserId, string referrerUserId)
        {
            return await "affiliate/rebinding".InternalApi()
                .PostJsonAsync(new { referralUserId, referrerUserId })
                .GetQueryResult();
        }

        public virtual async Task<QueryResult> ClearParent(string referralId)
        {
            return await $"affiliate/rebinding/{referralId}/parent".InternalApi()
                .DeleteAsync()
                .GetQueryResult();
        }

        public virtual async Task<PagedList<ReferralUser>> GetReferralUsers(string search, int page = 1, int pageSize = 20)
        {
            var affiliateResponse = await "affiliate/users".InternalApi()
                .SetQueryParam("search", search)
                .SetQueryParam("page", page)
                .SetQueryParam("pageSize", pageSize)
                .GetJsonAsync<PagedList<ReferralUser>>()
                .GetQueryResult();

            return affiliateResponse.Succeeded ? affiliateResponse.Data : new PagedList<ReferralUser>();
        }

        public virtual async Task<List<ReferralUserFlatTreeItem>> GetReferralUserFlatTree(string userId, int? depth = null)
        {
            var result = await $"affiliate/referrals/{userId}/tree/flat".InternalApi()
                .SetQueryParam(nameof(depth), depth)
                .GetJsonAsync<List<ReferralUserFlatTreeItem>>()
                .GetQueryResult();

            return result.Succeeded ? result.Data : new List<ReferralUserFlatTreeItem>();
        }

        public virtual async Task<List<ReferralUserFlatTreeItem>> GetAllReferralsFlatTrees(int? depth = null)
        {
            var result = await $"affiliate/referrals/trees/flat".InternalApi()
                .SetQueryParam(nameof(depth), depth)
                .GetJsonAsync<List<ReferralUserFlatTreeItem>>();

            return result;
        }
    }
}
