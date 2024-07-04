using Flurl.Http;
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

    public async Task<List<UserTask>> GetActionTasks(long tenantId)
    {
        return await "farming/admin/action-tasks".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<List<UserTask>>();
    }

    public async Task<UserTask> GetActionTask(long id)
    {
        return await $"farming/admin/action-tasks/{id}".InternalApi()
            .GetJsonAsync<UserTask>();
    }

    public async Task<List<UserTask>> CreateActionTask(ActionTaskDto actionTaskDto)
    {
        return await $"farming/admin/action-tasks".InternalApi()
            .PostJsonAsync<List<UserTask>>(actionTaskDto);
    }

    public async Task<List<UserTask>> UpdateActionTask(long id, ActionTaskDto actionTaskDto)
    {
        return await $"farming/admin/action-tasks/{id}".InternalApi()
            .PutJsonAsync<List<UserTask>>(actionTaskDto);
    }

    #endregion ActionTasks

    #region AdminUsers

    public async Task<List<User>> GetUsers(long tenantId)
    {
        return await "farming/admin/users".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<List<User>>();
    }

    public async Task<User> GetUser(long id, long tenantId)
    {
        return await $"farming/admin/users/{id}".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .GetJsonAsync<User>();
    }

    public async Task<List<Referral>> GetUserReferrals(long id, long tenantId, bool isActive = true)
    {
        return await $"farming/admin/users/{id}/referrals".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .SetQueryParam(nameof(isActive), isActive)
            .PutJsonAsync<List<Referral>>(null);
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

    public async Task<Reward> CreateReward(Reward reward)
    {
        return await "farming/admin/tenants".InternalApi()
            .PostJsonAsync<Reward>(reward);
    }

    public async Task<Reward> UpdateReward(long id, Reward reward)
    {
        return await $"farming/admin/tenants/{id}".InternalApi()
            .PutJsonAsync<Reward>(reward);
    }

    #endregion Reward

    #region Tenant

    public async Task<List<Tenant>> GetTenants()
    {
        return await $"farming/admin/tenants".InternalApi()
            .PostJsonAsync<List<Tenant>>(null);
    }

    public async Task<Tenant> GetTenant(long id)
    {
        return await $"farming/admin/tenants/{id}".InternalApi()
            .PostJsonAsync<Tenant>(null);
    }

    public async Task<Tenant> CreateTenant(Tenant tenant)
    {
        return await $"farming/admin/tenants".InternalApi()
            .PostJsonAsync<Tenant>(tenant);
    }

    public async Task<Tenant> UpdateTenant(long id, Tenant tenant)
    {
        return await $"farming/admin/tenants/{id}".InternalApi()
            .PostJsonAsync<Tenant>(tenant);
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

    #endregion Image
}
