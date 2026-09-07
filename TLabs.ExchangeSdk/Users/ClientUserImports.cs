using System;
using System.IO;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Users;

public class ClientUserImports
{
    public virtual async Task<UserImportJobDto> UploadCsvAsync(Stream csvStream, string fileName)
    {
        return await "userprofiles/admin/user-imports".InternalApi()
            .PostMultipartAsync(mp => mp.AddFile("file", csvStream, fileName))
            .ReceiveJson<UserImportJobDto>();
    }

    public virtual async Task<UserImportJobDto> GetJobAsync(Guid jobId)
    {
        return await $"userprofiles/admin/user-imports/{jobId}".InternalApi()
            .GetJsonAsync<UserImportJobDto>();
    }

    public virtual async Task RetryFailedAsync(Guid jobId)
    {
        await $"userprofiles/admin/user-imports/{jobId}/retry-failed".InternalApi()
            .PostAsync();
    }

    public virtual async Task<UserImportJobDto> SendInvitationsAsync(Guid jobId)
    {
        return await $"userprofiles/admin/user-imports/{jobId}/send-invitations".InternalApi()
            .PostAsync()
            .ReceiveJson<UserImportJobDto>();
    }
}
