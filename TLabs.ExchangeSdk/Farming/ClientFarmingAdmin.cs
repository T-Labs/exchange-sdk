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
                                    
    public async Task<TenantSettings> GetTenantSettings(long id)
    {
        return await $"farming/admin/tenants/{id}/settings".InternalApi()
            .GetJsonAsync<TenantSettings>();
    }
    
    public async Task<TenantSettings> CreateTenantSettings(long id, [FromBody] TenantSettingsCreateDto createDto)
    {
        return await $"farming/admin/tenants/{id}/settings".InternalApi()
            .PostJsonAsync<TenantSettings>(createDto);
    }

    public async Task<TenantSettings> UpdateTenantSettings(long id, [FromBody] TenantSettingsCreateDto createDto)
    {
        return await $"farming/admin/tenants/{id}/settings".InternalApi()
            .PutJsonAsync<TenantSettings>(createDto);
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

    public async Task<string> UploadTenantImage(IFormFile file, long tenantId)
    {
        return await "farming/admin/images/upload/tenant-image".InternalApi()
            .SetQueryParam(nameof(tenantId), tenantId)
            .PostJsonAsync(file)
            .ReceiveString();
    }

    #endregion Image
}
