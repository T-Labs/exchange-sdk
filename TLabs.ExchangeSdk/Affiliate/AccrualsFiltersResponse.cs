using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Affiliate;

public class AccrualsFiltersResponse
{
    public List<string> Currencies { get; set; } = new List<string>();
    public List<string> ProfitTypes { get; set; } = new List<string>();
}
