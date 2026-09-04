using System;
using System.IO;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Users;

public class ClientPartnerImports
{
    public virtual async Task<PartnerImportJobDto> UploadCsvAsync(Stream csvStream, string fileName)
    {
        return await "userprofiles/admin/partner-imports".InternalApi()
            .PostMultipartAsync(mp => mp.AddFile("file", csvStream, fileName))
            .ReceiveJson<PartnerImportJobDto>();
    }

    public virtual async Task<PartnerImportJobDto> GetJobAsync(Guid jobId)
    {
        return await $"userprofiles/admin/partner-imports/{jobId}".InternalApi()
            .GetJsonAsync<PartnerImportJobDto>();
    }

    public virtual async Task RetryFailedAsync(Guid jobId)
    {
        await $"userprofiles/admin/partner-imports/{jobId}/retry-failed".InternalApi()
            .PostAsync();
    }
}
