using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.TradingRobots.Models.MasterTrade;

public class ChannelOrderDto
{
    public long Id { get; set; }
    public long ChannelId { get; set; }
    public long? PositionId { get; set; }
    public string Type { get; set; }
    public string Side { get; set; }
    public string Exchange { get; set; }
    public string Market { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string Action { get; set; }
    public string OrderId { get; set; }
    public string Params { get; set; }
    public string Result { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Source { get; set; }
    public string ExchangeType { get; set; }
    public int Status { get; set; }
    public decimal FeeCost { get; set; }
    public string FeeCoin { get; set; }
    public decimal Ratio { get; set; }
    public string PositionSide { get; set; }
    public decimal Cost { get; set; }
}

public class ChannelOrdersListResponse
{
    public int Limit { get; set; }
    public int Total { get; set; }
    public List<ChannelOrderDto> Orders { get; set; } = new();
}
