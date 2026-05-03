using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.TradingRobots.Models.MasterTrade;

public class UserPositionDto
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public long ChannelId { get; set; }
    public string Market { get; set; }
    public string Side { get; set; }
    public int Status { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public long? ExchangeId { get; set; }
    public string Exchange { get; set; }
    public PositionStat Stat { get; set; }
    public bool Demo { get; set; }
    public string Futures { get; set; }
    public long? SignalPositionId { get; set; }
    public List<UserPositionOrderDto> Orders { get; set; } = new();
}

public class PositionStat
{
    public decimal Cost { get; set; }
    public decimal Profit { get; set; }
    public decimal Ostatok { get; set; }
    public decimal Process { get; set; }
    public int CountOpen { get; set; }
    public decimal AmountOpen { get; set; }
    public int CountClose { get; set; }
    public decimal ProfitPerc { get; set; }
    public decimal AmountClose { get; set; }
    public decimal AvgPriceOpen { get; set; }
    public decimal AvgPriceClose { get; set; }
    public decimal? FeeCost { get; set; }
    public decimal? CostOpen { get; set; }
    public decimal? CostClose { get; set; }
    public decimal? BalanceProfitPerc { get; set; }
}

public class UserPositionOrderDto
{
    public long Id { get; set; }
    public long ChannelId { get; set; }
    public long? SignalId { get; set; }
    public string UserId { get; set; }
    public long PositionId { get; set; }
    public string Type { get; set; }
    public string Side { get; set; }
    public long? ExchangeId { get; set; }
    public string Exchange { get; set; }
    public string Market { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset? CreateTime { get; set; }
    public DateTimeOffset? ExecuteTime { get; set; }
    public int Status { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string Error { get; set; }
    public string OrderId { get; set; }
    public string ExchangeType { get; set; }
    public string Config { get; set; }
    public decimal CreatePrice { get; set; }
    public bool Demo { get; set; }
    public decimal Balance { get; set; }
    public DateTimeOffset? OpenTime { get; set; }
    public string PositionSide { get; set; }
    public decimal Cost { get; set; }
}

public class UserPositionsListResponse
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
    public List<UserPositionDto> Positions { get; set; } = new();
}
