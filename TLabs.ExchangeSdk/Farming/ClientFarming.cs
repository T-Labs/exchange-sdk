using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Farming.Dtos;

namespace TLabs.ExchangeSdk.Farming;

public class ClientFarming
{
    public async Task<IFlurlResponse> ReloadTenants()
    {
        return await "farmingwebapp/tenants/reload".InternalApi()
            .PostAsync();
    }

    #region Auth

    public async Task<bool> CheckAuth(long tenantId, long tgUserId)
    {
        return await "farming/auth".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .GetJsonAsync<bool>();
    }

    #endregion Auth

    #region UserTasks

    public async Task<List<ActionTask>> GetUserTasks(long tenantId, long tgUserId)
    {
        return await "farming/user-tasks".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .GetJsonAsync<List<ActionTask>>();
    }

    public async Task<ActionTask> GetUserTask(long tenantId, long tgUserId, long id)
    {
        return await $"farming/user-tasks/{id}".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .GetJsonAsync<ActionTask>();
    }

    public async Task<ActionTask> StartUserTask(long tenantId, long tgUserId, long id)
    {
        return await $"farming/user-tasks/{id}".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .PutJsonAsync<ActionTask>(null);
    }

    public async Task<ActionTask> ClaimUserTask(long tenantId, long tgUserId, long id)
    {
        return await $"farming/user-tasks/{id}/claim".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .PutJsonAsync<ActionTask>(null);
    }

    #endregion UserTasks

    #region Farming

    public async Task<User> StartFarming(long tenantId, long tgUserId)
    {
        return await "farming/farmings/start".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .PutJsonAsync<User>(null);
    }

    public async Task<User> ClaimRewardFarming(long tenantId, long tgUserId)
    {
        return await "farming/farmings/claim".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .PutJsonAsync<User>(null);
    }

    #endregion Farming

    #region User

    public async Task<User> GetUserData(long tenantId, long tgUserId)
    {
        return await "farming/users/data".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .GetJsonAsync<User>();
    }

    public async Task<decimal> GetUserBalance(long tenantId, long tgUserId)
    {
        return await "farming/users/balance".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .GetJsonAsync<decimal>();
    }

    public async Task<User> UpdateUserName(long tenantId, long tgUserId, string userName)
    {
        return await "farming/users/name/update".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(userName), userName)
            .PutJsonAsync<User>(null);
    }

    public async Task<List<UserReferralsDto>> GetUserReferrals(long tenantId, long tgUserId, int maxLevels = 3)
    {
        return await "farming/users/referrals".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(maxLevels), maxLevels)
            .GetJsonAsync<List<UserReferralsDto>>();
    }

    public async Task<List<UserReferralsDto>> ClaimRewardForReferrals(long tenantId, long tgUserId, int maxLevels = 3)
    {
        return await "farming/users/referrals/claim".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(maxLevels), maxLevels)
            .PutJsonAsync<List<UserReferralsDto>>(null);
    }

    public async Task<User> ClaimDailyReward(long tenantId, long tgUserId)
    {
        return await "farming/users/daily/claim".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .PutJsonAsync<User>(null);
    }

    public async Task<decimal> ClaimRewardForMiniGame(MiniGameResultDto miniGameResultDto)
    {
        return await "farming/users/mini-game/claim".InternalApi()
            .PostJsonAsync<decimal>(miniGameResultDto);
    }

    public async Task<User> UpdateUserCountryCode(long tenantId, long tgUserId, string code)
    {
        return await "farming/users/country-codes".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(code), code)
            .PutJsonAsync<User>(null);
    }

    public async Task<User> UpdateUserLanguageCode(long tenantId, long tgUserId, string code)
    {
        return await "farming/users/language-codes".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(code), code)
            .PutJsonAsync<User>(null);
    }

    #endregion User

    #region Rewards

    public async Task<Reward> GetRewardByType(long tenantId, long tgUserId, RewardType rewardType)
    {
        return await "farming/rewards".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(rewardType), rewardType)
            .GetJsonAsync<Reward>();
    }

    public async Task<decimal> GetRewardAmount(long tenantId, long tgUserId, RewardType rewardType)
    {
        return await "farming/rewards/amount".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(tgUserId), tgUserId)
            .SetQueryParam(nameof(rewardType), rewardType)
            .GetJsonAsync<decimal>();
    }

    #endregion Rewards

    #region public

    public async Task<TenantDataDto> GetTenantData(long id)
    {
        return await $"farming/tenants/{id}/data".InternalApi()
            .GetJsonAsync<TenantDataDto>();
    }

    public async Task<bool> CheckUserName(string userName)
    {
        return await $"farming/users/name/check".InternalApi()
            .SetQueryParam(nameof(userName), userName)
            .GetJsonAsync<bool>();
    }

    public async Task<IFlurlResponse> Registration(RegistrationDto registrationDto)
    {
        return await $"farming/auth/registration".InternalApi()
            .PostJsonAsync(registrationDto);
    }

    #region Image

    public async Task<IActionResult> GetImages(string id)
    {
        var image = await $"farming/images/{id}".InternalApi()
            .GetJsonAsync<byte[]>();

        string[] strArray = id.Split('.', StringSplitOptions.RemoveEmptyEntries);
        string str = "";
        if (strArray.Length == 2)
            str = strArray[1];

        return FileContentResultHelper.GetFileContentResult(str, image);
    }

    public async Task<string> UploadImage(UploadImageDto uploadImageDto)
    {
        return await "farming/images/upload".InternalApi()
            .PutJsonAsync(uploadImageDto)
            .ReceiveString();
    }

    #endregion Image

    #endregion public
}
