using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Users;

public class ClientUserImportInvitations
{
    public virtual async Task<SendUserImportInvitationsResponse> SendSolidarInvitationsAsync(IReadOnlyList<string> userIds)
    {
        return await "identity/admin/user-imports/send-invitations".InternalApi()
            .PostJsonAsync(new SendUserImportInvitationsRequest { UserIds = new List<string>(userIds) })
            .ReceiveJson<SendUserImportInvitationsResponse>();
    }
}
