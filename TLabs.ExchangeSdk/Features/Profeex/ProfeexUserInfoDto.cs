using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexUserInfoDto
{
    public long UserId { get; set; }

    /// <summary>Balance dictionary keyed by currency code (e.g. TRX, USDT) in string-decimal form.</summary>
    public Dictionary<string, string> Balances { get; set; } = new();

    public string DepositAddress { get; set; }

    public DateTimeOffset? RegistrationDate { get; set; }
}
