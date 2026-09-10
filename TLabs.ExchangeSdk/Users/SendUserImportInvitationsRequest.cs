using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Users;

public class SendUserImportInvitationsRequest
{
    public List<string> UserIds { get; set; } = new List<string>();
}

public class SendUserImportInvitationResult
{
    public string UserId { get; set; }

    public bool Succeeded { get; set; }

    public string Error { get; set; }
}

public class SendUserImportInvitationsResponse
{
    public List<SendUserImportInvitationResult> Results { get; set; } = new List<SendUserImportInvitationResult>();
}
