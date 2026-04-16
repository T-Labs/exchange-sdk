using System;
using System.Collections.Generic;
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

        public async Task<List<Profit>> GetProfits(List<Guid> ids)
        {
            var result = await $"affiliate/profits".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .PostJsonAsync<List<Profit>>(ids);
            return result;
        }

        public async Task<PagedList<AccrualDto>> GetAccruals(string userId, int pageNumber = 1, int pageSize = 20,
            string currencyCode = null, ProfitType? profitType = null)
        {
            var request = $"affiliate/accruals".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(pageNumber), pageNumber)
                .SetQueryParam(nameof(pageSize), pageSize);

            if (currencyCode != null)
                request = request.SetQueryParam(nameof(currencyCode), currencyCode);
            if (profitType != null)
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
    }
}
