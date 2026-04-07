using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Staking;

public class GetUserStakesTotalRequest
{
    public List<string> UserIds { get; set; }
    public string CurrencyCode { get; set; }
}
