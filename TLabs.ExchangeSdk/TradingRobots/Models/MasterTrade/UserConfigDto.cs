using System;

namespace TLabs.ExchangeSdk.TradingRobots.Models.MasterTrade;

public class UserConfigDto
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public long ChannelId { get; set; }
    public int Work { get; set; }
    public string Config { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Error { get; set; }
    public DateTimeOffset? ErrorAt { get; set; }
    public long? ExchangeId { get; set; }
    public string Exchange { get; set; }
    public DateTimeOffset? WorkAt { get; set; }
}

public class SaveUserConfigRequest
{
    public long ExchangeId { get; set; }
    /// <summary>Required for profitsharing channels. Drawdown limit (e.g. 0.1 = 10%).</summary>
    public decimal? MaxSlump { get; set; }
    /// <summary>Optional. 1 = start trading, 0 = stop.</summary>
    public int? Work { get; set; }
}

public class LaunchUserChannelRequest
{
    /// <summary>1 = start, 0 = stop, 9 = stop and close all open positions.</summary>
    public int Work { get; set; }
}

public class UserProfitsResponse
{
    public string Coin { get; set; }
    public string StatUserOrders { get; set; }
    public UserProfitsValues StatUserProfits { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
}

public class UserProfitsValues
{
    public decimal EndValue { get; set; }
    public string Values { get; set; }
    public string Session { get; set; }
}
