namespace TLabs.ExchangeSdk.TradingRobots.Models;

public class ExchangeAccountDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string KeyShort { get; set; }
    public string KeyCode { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public bool Hold { get; set; }
}

public class AddExchangeAccountRequest
{
    public string Exchange { get; set; }
    public string Key { get; set; }
    public string Description { get; set; }
}

public class DisableExchangeAccountResult
{
    public string Exchange { get; set; }
    public int Count { get; set; }
}
