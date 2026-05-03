using System;

namespace TLabs.ExchangeSdk.TradingRobots.Models.MasterTrade;

public class ChannelDto
{
    public long Id { get; set; }
    public long? ServiceItemId { get; set; }
    public long? AnalystUserId { get; set; }
    public bool Active { get; set; }
    public bool Launch { get; set; }
    public string Hash { get; set; }
    public string Exchange { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Balance { get; set; }
    public string Coin { get; set; }
    public string Error { get; set; }
    public DateTimeOffset? ErrorAt { get; set; }
    public string Version { get; set; }
    public string Config { get; set; }
    public DateTimeOffset? LaunchAt { get; set; }
    public string ExchangeMode { get; set; }
    public bool Demo { get; set; }
    public string ServiceName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public bool ProRequired { get; set; }
    public string PurchaseMethod { get; set; }
    public bool? Disabled { get; set; }
}

public class ChannelInfoDto : ChannelDto
{
    public ChannelStatSummary ChannelStatSummary { get; set; }
    public UserStatSummary UserStatSummary { get; set; }
}

public class ChannelStatSummary
{
    public int Followers { get; set; }
    public int Signals { get; set; }
    public decimal? BalanceProfitPerc { get; set; }
    public int Days { get; set; }
}

public class UserStatSummary
{
    public int OpenPositions { get; set; }
    public int Orders { get; set; }
    public decimal? Profit { get; set; }
}
