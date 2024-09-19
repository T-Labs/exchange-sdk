using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Farming.Dtos;

namespace TLabs.ExchangeSdk.Farming;

public class ClientFarmingAdmin
{
    #region ActionTasks

    public async Task<List<ActionTask>> GetActionTasks(long tenantId, bool onlyActive = true)
    {
        return await "farming/action-tasks".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(onlyActive), onlyActive)
            .GetJsonAsync<List<ActionTask>>();
    }

    public async Task<ActionTask> GetActionTask(long id)
    {
        return await $"farming/action-tasks/{id}".InternalApi()
            .GetJsonAsync<ActionTask>();
    }

    public async Task<ActionTask> CreateActionTask(ActionTaskDto actionTaskDto)
    {
        return await $"farming/action-tasks".InternalApi()
            .PostJsonAsync<ActionTask>(actionTaskDto);
    }

    public async Task<ActionTask> UpdateActionTask(long id, ActionTaskDto actionTaskDto)
    {
        return await $"farming/action-tasks/{id}".InternalApi()
            .PutJsonAsync<ActionTask>(actionTaskDto);
    }

    #endregion ActionTasks

    #region AdminUsers

    public async Task<PagedList<User>> GetUsers(long tenantId, int page = 1, int pageSize = 10,
        string filterText = null)
    {
        return await "farming/users".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(page), page)
            .SetQueryParam(nameof(pageSize), pageSize)
            .SetQueryParam(nameof(filterText), filterText)
            .GetJsonAsync<PagedList<User>>();
    }

    public async Task<User> GetUser(long tenantId, long id)
    {
        return await $"farming/users/{id}".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<User>();
    }

    public async Task<List<UserInfo>> GetReferralUsers(long tenantId, long id, bool isOnlyActive = true)
    {
        return await $"farming/users/{id}/referral-users".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(isOnlyActive), isOnlyActive)
            .GetJsonAsync<List<UserInfo>>();
    }

    public async Task<User> UpdateReferralLimit(long tenantId, long id, int newLimit)
    {
        return await $"farming/users/{id}/referrals/limits".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(newLimit), newLimit)
            .PutJsonAsync<User>(null);
    }

    public async Task<List<UserInfo>> GetUserInfos(long tenantId)
    {
        return await "farming/users/infos".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<List<UserInfo>>();
    }

    /// <summary>Get counts of users in each region and how many connected wallets</summary>
    public async Task<UserCountsByRegion> GetUserCountsByRegions(long tenantId)
    {
        var result = await "farming/users/counts-by-region".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<UserCountsByRegion>();
        return result;
    }

    #endregion AdminUsers

    #region Reward

    public async Task<List<Reward>> GetRewards(long tenantId)
    {
        return await "farming/rewards/all".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<List<Reward>>();
    }

    public async Task<Reward> CreateReward(RewardCreateDto rewardCreateDto)
    {
        return await "farming/rewards".InternalApi()
            .PostJsonAsync<Reward>(rewardCreateDto);
    }

    public async Task<Reward> UpdateReward(long id, RewardCreateDto rewardCreateDto)
    {
        return await $"farming/rewards/{id}".InternalApi()
            .PutJsonAsync<Reward>(rewardCreateDto);
    }

    #endregion Reward

    #region Tenant

    public async Task<List<Tenant>> GetTenants()
    {
        return await $"farming/tenants".InternalApi()
            .GetJsonAsync<List<Tenant>>();
    }

    public async Task<Tenant> GetTenant(long id)
    {
        return await $"farming/tenants/{id}".InternalApi()
            .GetJsonAsync<Tenant>();
    }

    public async Task<Tenant> CreateTenant(TenantCreateDto tenantCreateDto)
    {
        return await $"farming/tenants".InternalApi()
            .PostJsonAsync<Tenant>(tenantCreateDto);
    }

    public async Task<Tenant> UpdateTenant(long id, TenantCreateDto tenantCreateDto)
    {
        return await $"farming/tenants/{id}".InternalApi()
            .PutJsonAsync<Tenant>(tenantCreateDto);
    }

    #endregion Tenant

    #region Transaction

    public async Task<IFlurlResponse> CreateTransaction(Transaction transaction)
    {
        return await $"farming/admin/transactions".InternalApi()
            .PostJsonAsync(transaction);
    }

    #endregion Transaction

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

    public async Task<string> UploadTenantImage(UploadImageDto model, long tenantId)
    {
        return await "farming/images/upload/tenant-image".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .PostJsonAsync(model)
            .ReceiveString();
    }

    #endregion Image
}
