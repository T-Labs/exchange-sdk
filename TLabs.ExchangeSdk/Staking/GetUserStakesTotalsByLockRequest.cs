using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Staking;

public class GetUserStakesTotalsByLockRequest
{
    public List<string> UserIds { get; set; }

    public string CurrencyCode { get; set; }
}
