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
    #region Auth

    public async Task<bool> CheckAuth()
    {
        return await "farming/auth".InternalApi()
            .GetJsonAsync<bool>();
    }

    #endregion Auth

    #region UserTasks

    public async Task<List<UserTask>> GetUserTasks()
    {
        return await "farming/user-tasks".InternalApi()
            .GetJsonAsync<List<UserTask>>();
    }

    public async Task<List<UserTask>> StartUserTask(long id)
    {
        return await $"farming/user-tasks/{id}".InternalApi()
            .PutJsonAsync<List<UserTask>>(null);
    }

    public async Task<List<UserTask>> ClaimUserTask(long id)
    {
        return await $"farming/user-tasks/{id}/claim".InternalApi()
            .PutJsonAsync<List<UserTask>>(null);
    }

    #endregion UserTasks

    #region Farming

    public async Task<decimal> GetAmountReward()
    {
        return await "farming/farmings/reward".InternalApi()
            .GetJsonAsync<decimal>();
    }

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

    public async Task<IFlurlResponse> StartMiniGameFarming()
    {
        return await "farming/farmings/mini-game/start".InternalApi()
            .PutAsync();
    }

    public async Task<IFlurlResponse> FinishMiniGameFarming()
    {
        return await "farming/farmings/mini-game/finish".InternalApi()
            .PutAsync();
    }

    #endregion Farming

    #region User

    public async Task<User> GetUserData()
    {
        return await "farming/users".InternalApi()
            .GetJsonAsync<User>();
    }

    public async Task<decimal> GetUserBalance()
    {
        return await "farming/users/balance".InternalApi()
            .GetJsonAsync<decimal>();
    }

    public async Task<List<UserReferralsDto>> GetUserReferrals()
    {
        return await "farming/users/referrals".InternalApi()
            .GetJsonAsync<List<UserReferralsDto>>();
    }

    public async Task<List<UserReferralsDto>> ClaimRewardForReferrals()
    {
        return await "farming/users/referrals/claim".InternalApi()
            .PutJsonAsync<List<UserReferralsDto>>(null);
    }

    public async Task<User> ClaimDailyReward()
    {
        return await "farming/users/daily/claim".InternalApi()
            .PutJsonAsync<User>(null);
    }

    #endregion User

    #region Tenant

    public async Task<IFlurlResponse> CreateTenant([FromBody] Tenant tenant)
    {
        return await $"farming/tenants".InternalApi()
            .PostJsonAsync(tenant);
    }

    #endregion Tenant

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

    public async Task<IFlurlResponse> Registration([FromBody] RegistrationDto registrationDto)
    {
        return await $"farming/auth/registration".PostJsonAsync(registrationDto);
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

    public async Task<string> UploadImage([FromBody] UploadImageDto uploadImageDto)
    {
        return await "farming/images/upload".InternalApi()
            .PutJsonAsync(uploadImageDto)
            .ReceiveString();
    }

    #endregion Image

    #endregion public
}
