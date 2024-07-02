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
        return await "api/auth".InternalApi()
            .GetJsonAsync<bool>();
    }

    #endregion Auth

    #region UserTasks

    public async Task<List<UserTask>> GetUserTasks()
    {
        return await "api/user-tasks".InternalApi()
            .GetJsonAsync<List<UserTask>>();
    }

    public async Task<List<UserTask>> StartUserTask(long id)
    {
        return await $"api/user-tasks/{id}".InternalApi()
            .PutJsonAsync<List<UserTask>>(null);
    }

    public async Task<List<UserTask>> ClaimUserTask(long id)
    {
        return await $"api/user-tasks/{id}/claim".InternalApi()
            .PutJsonAsync<List<UserTask>>(null);
    }

    #endregion UserTasks

    #region Farming

    public async Task<decimal> GetAmountReward()
    {
        return await "api/farmings/reward".InternalApi()
            .GetJsonAsync<decimal>();
    }

    public async Task<User> StartFarming()
    {
        return await "api/farmings/start".InternalApi()
            .PutJsonAsync<User>(null);
    }

    public async Task<User> ClaimRewardFarming()
    {
        return await "api/farmings/claim".InternalApi()
            .PutJsonAsync<User>(null);
    }

    public async Task<IFlurlResponse> StartMiniGameFarming()
    {
        return await "api/farmings/mini-game/start".InternalApi()
            .PutAsync();
    }

    public async Task<IFlurlResponse> FinishMiniGameFarming()
    {
        return await "api/farmings/mini-game/finish".InternalApi()
            .PutAsync();
    }

    #endregion Farming

    #region User

    public async Task<User> GetUserData()
    {
        return await "api/users".InternalApi()
            .GetJsonAsync<User>();
    }

    public async Task<decimal> GetUserBalance()
    {
        return await "api/users/balance".InternalApi()
            .GetJsonAsync<decimal>();
    }

    public async Task<List<UserReferralsDto>> GetUserReferrals()
    {
        return await "api/users/referrals".InternalApi()
            .GetJsonAsync<List<UserReferralsDto>>();
    }

    public async Task<List<UserReferralsDto>> ClaimRewardForReferrals()
    {
        return await "api/users/referrals/claim".InternalApi()
            .PutJsonAsync<List<UserReferralsDto>>(null);
    }

    public async Task<User> ClaimDailyReward()
    {
        return await "api/users/daily/claim".InternalApi()
            .PutJsonAsync<User>(null);
    }

    #endregion User

    #region Tenant

    public async Task<IFlurlResponse> CreateTenant([FromBody] Tenant tenant)
    {
        return await $"api/tenants".InternalApi()
            .PostJsonAsync(tenant);
    }

    #endregion Tenant

    #region public

    public async Task<TenantDataDto> GetTenantData(long id)
    {
        return await $"api/tenants/{id}".InternalApi()
            .GetJsonAsync<TenantDataDto>();
    }

    public async Task<bool> CheckUserName(string userName)
    {
        return await $"api/users/name/check".InternalApi()
            .SetQueryParam(nameof(userName), userName)
            .GetJsonAsync<bool>();
    }

    public async Task<IFlurlResponse> Registration([FromBody] RegistrationDto registrationDto)
    {
        return await $"api/auth/registration".PostJsonAsync(registrationDto);
    }

    #region Image

    public async Task<IActionResult> GetImages(string id)
    {
        var image = await $"api/images/{id}".InternalApi()
            .GetJsonAsync<byte[]>();

        string[] strArray = id.Split('.', StringSplitOptions.RemoveEmptyEntries);
        string str = "";
        if (strArray.Length == 2)
            str = strArray[1];

        FileContentResult fileContentResult = null;
        switch (str)
        {
            case "gif":
                return new FileContentResult(image, "image/gif");

            case "png":
                return new FileContentResult(image, "image/png");

            case "webp":
                return new FileContentResult(image, "image/webp");

            default:
                return new FileContentResult(image, "image/jpeg");
        }
    }

    public async Task<string> UploadImage([FromBody] UploadImageDto uploadImageDto)
    {
        return await "api/images/upload".InternalApi()
            .PutJsonAsync(uploadImageDto)
            .ReceiveString();
    }

    #endregion Image

    #endregion public
}
