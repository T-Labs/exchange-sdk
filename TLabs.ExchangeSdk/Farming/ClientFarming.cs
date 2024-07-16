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

    public async Task<bool> CheckAuth()
    {
        return await "farming/auth".InternalApi()
            .GetJsonAsync<bool>();
    }

    #endregion Auth

    #region UserTasks

    public async Task<List<ActionTask>> GetUserTasks()
    {
        return await "farming/user-tasks".InternalApi()
            .GetJsonAsync<List<ActionTask>>();
    }

    public async Task<ActionTask> GetUserTask(long id)
    {
        return await $"farming/user-tasks/{id}".InternalApi()
            .GetJsonAsync<ActionTask>();
    }

    public async Task<ActionTask> StartUserTask(long id)
    {
        return await $"farming/user-tasks/{id}".InternalApi()
            .PutJsonAsync<ActionTask>(null);
    }

    public async Task<ActionTask> ClaimUserTask(long id)
    {
        return await $"farming/user-tasks/{id}/claim".InternalApi()
            .PutJsonAsync<ActionTask>(null);
    }

    #endregion UserTasks

    #region Farming

    public async Task<User> StartFarming()
    {
        return await "farming/farmings/start".InternalApi()
            .PutJsonAsync<User>(null);
    }

    public async Task<User> ClaimRewardFarming()
    {
        return await "farming/farmings/claim".InternalApi()
            .PutJsonAsync<User>(null);
    }

    #endregion Farming

    #region User

    public async Task<User> GetUserData()
    {
        return await "farming/users".InternalApi()
            .GetJsonAsync<User>();
    }

    public async Task<User> UpdateUserName(string userName)
    {
        return await "farming/users/name/update".InternalApi()
            .SetQueryParam(nameof(userName), userName)
            .PutJsonAsync<User>(null);
    }

    public async Task<decimal> GetUserBalance()
    {
        return await "farming/users/balance".InternalApi()
            .GetJsonAsync<decimal>();
    }

    public async Task<List<UserReferralsDto>> GetUserReferrals(int maxLevels = 3)
    {
        return await "farming/users/referrals".InternalApi()
            .SetQueryParam(nameof(maxLevels), maxLevels)
            .GetJsonAsync<List<UserReferralsDto>>();
    }

    public async Task<List<UserReferralsDto>> ClaimRewardForReferrals(int maxLevels = 3)
    {
        return await "farming/users/referrals/claim".InternalApi()
            .SetQueryParam(nameof(maxLevels), maxLevels)
            .PutJsonAsync<List<UserReferralsDto>>(null);
    }

    public async Task<User> ClaimDailyReward()
    {
        return await "farming/users/daily/claim".InternalApi()
            .PutJsonAsync<User>(null);
    }

    public async Task<decimal> ClaimRewardForMiniGame(MiniGameResultDto miniGameResultDto)
    {
        return await "farming/users/mini-game/claim".InternalApi()
            .PostJsonAsync<decimal>(miniGameResultDto);
    }

    #endregion User

    #region Rewards

    public async Task<Reward> GetRewardByType(RewardType rewardType)
    {
        return await "farming/rewards".InternalApi()
            .SetQueryParam(nameof(rewardType), rewardType)
            .GetJsonAsync<Reward>();
    }

    public async Task<decimal> GetRewardAmount(RewardType rewardType)
    {
        return await "farming/rewards/amount".InternalApi()
            .SetQueryParam(nameof(rewardType), rewardType)
            .GetJsonAsync<decimal>();
    }

    #endregion Rewards

    #region public

    public async Task<TenantDataDto> GetTenantData(long id)
    {
        return await $"farming/tenants/{id}".InternalApi()
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
