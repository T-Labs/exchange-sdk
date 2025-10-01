using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CryptoAdapters.Tron;

public class ClientCryptoAdapterOrgon
{
    public ClientCryptoAdapterOrgon()
    {
    }

    public async Task<ExternalFreezesDto> GetExternalFreezeDelegations()
    {
        var result = await $"orgon/external/freeze-delegations".InternalApi()
            .GetJsonAsync<ExternalFreezesDto>();
        return result;
    }

    public async Task<TronTransaction> ExternalDelegateOrUndelegate(ExternalDelegateRequest request)
    {
        var result = await $"orgon/external/freeze-delegations".InternalApi()
            .PostJsonAsync<TronTransaction>(request);
        return result;
    }
}
