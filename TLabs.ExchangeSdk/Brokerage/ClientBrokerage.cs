using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Brokerage;

public class ClientBrokerage
{
    public async Task<bool> GetVerificationRequired()
    {
        return await "brokerage/parameters/verification".InternalApi()
            .GetJsonAsync<bool>();
    }
}
