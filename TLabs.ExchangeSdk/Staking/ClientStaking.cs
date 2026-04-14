using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Staking
{
    public class ClientStaking
    {
        private readonly ILogger _logger;

        public ClientStaking(
            ILogger<ClientStaking> logger)
        {
            _logger = logger;
        }

        public async Task<List<StakingSetting>> GetSettings()
        {
            var result = await $"brokerage/staking/settings".InternalApi()
                .GetJsonAsync<List<StakingSetting>>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        public async Task<StakingSetting> GetSetting(int stakingSettingId)
        {
            return await $"brokerage/staking/settings/{stakingSettingId}".InternalApi()
                .GetJsonAsync<StakingSetting>();
        }

        public async Task<IFlurlResponse> AddSetting(StakingSetting stakingSetting)
        {
            return await $"brokerage/staking/settings".InternalApi().PostJsonAsync(stakingSetting);
        }

        public async Task<IFlurlResponse> UpdateSetting(StakingSetting stakingSetting)
        {
            return await $"brokerage/staking/settings".InternalApi().PutJsonAsync(stakingSetting);
        }

        public async Task<IFlurlResponse> DeleteSetting(Guid stakingSettingId)
        {
            return await $"brokerage/staking/settings/{stakingSettingId}".InternalApi().DeleteAsync();
        }

        public async Task<List<StakingAccrual>> GetAccrualsByStakingSettingId(int stakingSettingId)
        {
            return await $"brokerage/staking/accruals".InternalApi()
                .SetQueryParam(nameof(stakingSettingId), stakingSettingId)
                .GetJsonAsync<List<StakingAccrual>>();
        }

        public async Task<StakingTransactionsDto> GetAccrualTransactions(string userId,
            string currencyCode = null, int pageNumber = 1, int pageSize = 20)
        {
            var result = await $"brokerage/staking/accrual-transactions".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(pageNumber), pageNumber.ToString())
                .SetQueryParam(nameof(pageSize), pageSize.ToString())
                .GetJsonAsync<StakingTransactionsDto>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        public async Task<QueryResult<string>> Stake(CreateUserStakeDto dto)
        {
            var result = await $"brokerage/staking/stake".InternalApi()
                .PostJsonAsync<string>(dto).GetQueryResult();
            if (!result.Succeeded)
                _logger.LogError($"{result.ErrorsString} for {dto}");
            return result;
        }

        public async Task<List<UserStake>> GetUserStakes(string userId, UserStakingStatus? status = null)
        {
            var result = await $"brokerage/staking/user-stakes".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(status), status?.ToString())
                .GetJsonAsync<List<UserStake>>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        public async Task<UserStake> GetUserStake(string userId, Guid stakeId)
        {
            var result = await $"brokerage/staking/user-stakes/{stakeId}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<UserStake>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        public virtual async Task<decimal> GetUserStakesTotal(string userId, string currencyCode)
        {
            var request = new GetUserStakesTotalRequest
            {
                UserIds = new List<string> { userId },
                CurrencyCode = currencyCode
            };
            var result = await GetUsersStakesTotal(request);
            return result.GetValueOrDefault(userId, 0);
        }

        public virtual async Task<Dictionary<string, decimal>> GetUsersStakesTotal(GetUserStakesTotalRequest request)
        {
            var result = await $"brokerage/staking/user-stakes/total".InternalApi()
                .PostJsonAsync<Dictionary<string, decimal>>(request).GetQueryResult();
            return result.Succeeded ? result.Data : new Dictionary<string, decimal>();
        }

        public async Task<List<UserStake>> GetAllUserStakes(UserStakingStatus? status = null)
        {
            var result = await $"brokerage/staking/all-user-stakes".InternalApi()
                .SetQueryParam(nameof(status), status?.ToString())
                .GetJsonAsync<List<UserStake>>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        public virtual async Task<StakingStatisticsDto> GetStakingStatistics(IReadOnlyCollection<string> userIds)
        {
            var result = await $"brokerage/staking/statistics"
                .InternalApi().PostJsonAsync<StakingStatisticsDto>(userIds).GetQueryResult();

            return result.Succeeded ? result.Data : new StakingStatisticsDto();
        }

        public virtual async Task<int> GetStakesCountForPeriod(GetStakedCountForPeriodRequest request)
        {
            var result = await $"brokerage/staking/statistics/stakes-count"
                .InternalApi().PostJsonAsync<int>(request).GetQueryResult();

            return result.Succeeded ? result.Data : 0;
        }
    }
}
