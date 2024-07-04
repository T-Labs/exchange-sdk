using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Farming;

public class TenantsCache
{
    private List<Tenant> tenants { get; set; }

    public async Task<List<Tenant>> GetTenants()
    {
        if (tenants != null)
            await LoadTenants();

        return tenants;
    }

    public async Task LoadTenants()
    {
        var result = await $"farming/admin/tenants".InternalApi()
            .GetJsonAsync<List<Tenant>>();

        tenants = result;
    }
}
