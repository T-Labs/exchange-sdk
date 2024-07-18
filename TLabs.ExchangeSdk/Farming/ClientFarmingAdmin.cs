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
        return await "farming/admin/action-tasks".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(onlyActive), onlyActive)
            .GetJsonAsync<List<ActionTask>>();
    }

    public async Task<ActionTask> GetActionTask(long id)
    {
        return await $"farming/admin/action-tasks/{id}".InternalApi()
            .GetJsonAsync<ActionTask>();
    }

    public async Task<ActionTask> CreateActionTask(ActionTaskDto actionTaskDto)
    {
        return await $"farming/admin/action-tasks".InternalApi()
            .PostJsonAsync<ActionTask>(actionTaskDto);
    }

    public async Task<ActionTask> UpdateActionTask(long id, ActionTaskDto actionTaskDto)
    {
        return await $"farming/admin/action-tasks/{id}".InternalApi()
            .PutJsonAsync<ActionTask>(actionTaskDto);
    }

    #endregion ActionTasks

    #region AdminUsers

    public async Task<PagedList<User>> GetUsers(long tenantId, int page = 1, int pageSize = 10)
    {
        return await "farming/admin/users".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(page), page)
            .SetQueryParam(nameof(pageSize), pageSize)
            .GetJsonAsync<PagedList<User>>();
    }

    public async Task<User> GetUser(long id, long tenantId)
    {
        return await $"farming/admin/users/{id}".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<User>();
    }

    public async Task<List<Referral>> GetUserReferrals(long id, long tenantId, bool isOnlyActive = true)
    {
        return await $"farming/admin/users/{id}/referrals".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(isOnlyActive), isOnlyActive)
            .GetJsonAsync<List<Referral>>();
    }

    public async Task<User> UpdateReferralLimit(long id, long tenantId, int newLimit)
    {
        return await $"farming/admin/users/{id}/referrals/limits".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(newLimit), newLimit)
            .PutJsonAsync<User>(null);
    }

    #endregion AdminUsers

    #region Reward

    public async Task<List<Reward>> GetRewards(long tenantId)
    {
        return await "farming/admin/tenants".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<List<Reward>>();
    }

    public async Task<Reward> CreateReward(RewardCreateDto rewardCreateDto)
    {
        return await "farming/admin/tenants".InternalApi()
            .PostJsonAsync<Reward>(rewardCreateDto);
    }

    public async Task<Reward> UpdateReward(long id, RewardCreateDto rewardCreateDto)
    {
        return await $"farming/admin/tenants/{id}".InternalApi()
            .PutJsonAsync<Reward>(rewardCreateDto);
    }

    #endregion Reward

    #region Tenant

    public async Task<List<Tenant>> GetTenants()
    {
        return await $"farming/admin/tenants".InternalApi()
            .GetJsonAsync<List<Tenant>>();
    }

    public async Task<Tenant> GetTenant(long id)
    {
        return await $"farming/admin/tenants/{id}".InternalApi()
            .GetJsonAsync<Tenant>();
    }

    public async Task<Tenant> CreateTenant(TenantCreateDto tenantCreateDto)
    {
        return await $"farming/admin/tenants".InternalApi()
            .PostJsonAsync<Tenant>(tenantCreateDto);
    }

    public async Task<Tenant> UpdateTenant(long id, TenantCreateDto tenantCreateDto)
    {
        return await $"farming/admin/tenants/{id}".InternalApi()
            .PutJsonAsync<Tenant>(tenantCreateDto);
    }

    #endregion Tenant

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
        return await "farming/admin/images/upload/tenant-image".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .PostJsonAsync(model)
            .ReceiveString();
    }

    #endregion Image
}
