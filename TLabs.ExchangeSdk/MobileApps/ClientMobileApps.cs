using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.MobileApps
{
    public class ClientMobileApps
    {
        public async Task<MobileAppVersionDto> GetLatestVersion()
        {
            var result = await "brokerage/mobile-apps/versions/latest".InternalApi()
                .AllowAnyHttpStatus()
                .GetJsonAsync<MobileAppVersionDto>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        public async Task<IFlurlResponse> CreateVersion(MobileAppVersionCreateDto dto)
        {
            return await "brokerage/mobile-apps/versions".InternalApi()
                .AllowAnyHttpStatus()
                .PostJsonAsync(dto);
        }
    }
}
