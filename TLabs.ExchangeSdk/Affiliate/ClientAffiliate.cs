using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var result = await $"affiliate/users".InternalApi()
                .PostJsonAsync<List<ReferralUser>>(userIds);
            return result;
        }

        public async Task<AffiliateUserInfo> GetUserInfo(string userId)
        {
            var result = await $"affiliate/user-info/{userId}".InternalApi()
                .GetJsonAsync<AffiliateUserInfo>();
            return result;
        }

        public async Task<IFlurlResponse> ChangeUserTariff(string userId, TariffType tariffType)
        {
            var result = await $"affiliate/users/{userId}/tariffs".InternalApi()
                .SetQueryParam(nameof(tariffType), tariffType)
                .PostAsync();
            return result;
        }

        public async Task<List<Profit>> GetProfits(List<Guid> ids)
        {
            var result = await $"affiliate/profits".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .PostJsonAsync<List<Profit>>(ids);
            return result;
        }

        public async Task<PagedList<AccrualDto>> GetAccruals(string userId,
            int pageNumber = 1, int pageSize = 20)
        {
            var result = await $"affiliate/accruals".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(pageNumber), pageNumber)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<AccrualDto>>();
            return result;
        }

        public async Task<List<TotalAccrualsInfo>> GetTotalAccruals(string userId)
        {
            var result = await $"affiliate/total-accruals".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<List<TotalAccrualsInfo>>();
            return result;
        }
    }
}
