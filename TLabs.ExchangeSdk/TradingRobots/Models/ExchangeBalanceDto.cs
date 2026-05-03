using System.Collections.Generic;

namespace TLabs.ExchangeSdk.TradingRobots.Models;

public class ExchangeBalanceDto
{
    public Dictionary<string, string> Info { get; set; } = new();
    public Dictionary<string, decimal> Total { get; set; } = new();
    public Dictionary<string, decimal> Used { get; set; } = new();
    public Dictionary<string, decimal> Free { get; set; } = new();
}
