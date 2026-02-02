using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IFlurlResponse> DeleteSetting(int stakingSettingId)
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

        public async Task<QueryResult<string>> StakeLockOrUnlock(StakingLockDto dto)
        {
            var result = await $"brokerage/staking/stake".InternalApi()
                .PostJsonAsync<string>(dto).GetQueryResult();
            if (!result.Succeeded)
                _logger.LogError($"{result.ErrorsString} for {dto}");
            return result;
        }

        public async Task<decimal> GetTotalLockedAmount(string currencyCode)
        {
            var result = await $"depository/stakes/total-locked".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .GetJsonAsync<decimal>();
            return result;
        }
    }
}
