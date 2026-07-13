using System;

namespace TLabs.ExchangeSdk.Users;

public class TelegramLinkTokenDto
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}
