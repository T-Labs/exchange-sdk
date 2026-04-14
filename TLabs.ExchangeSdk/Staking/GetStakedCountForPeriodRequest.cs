using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Staking;

public class GetStakedCountForPeriodRequest
{
    public DateTimeOffset FromDate { get; set; }
    public DateTimeOffset ToDate { get; set; }
    public IReadOnlyCollection<string> UserIds { get; set; }
}
