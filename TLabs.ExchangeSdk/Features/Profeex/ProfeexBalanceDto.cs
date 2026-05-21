using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexBalanceDto
{
    public long UserId { get; set; }

    public Dictionary<string, string> Balances { get; set; } = new();
}
