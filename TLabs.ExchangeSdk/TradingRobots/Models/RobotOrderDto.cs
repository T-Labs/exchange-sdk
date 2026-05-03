using System;

namespace TLabs.ExchangeSdk.TradingRobots.Models;

public class RobotOrderDto
{
    public long Id { get; set; }
    public long RobotId { get; set; }
    public long UserId { get; set; }
    public long ExchangeId { get; set; }
    public string Exchange { get; set; }
    public string Market { get; set; }
    public decimal EntranceAmount { get; set; }
    public decimal EntrancePrice { get; set; }
    public decimal EgressAmount { get; set; }
    public decimal EgressPrice { get; set; }
    public decimal Profit { get; set; }
    public decimal Fee { get; set; }
    public decimal MinAmount { get; set; }
    public string Config { get; set; }
    public string Input { get; set; }
    public bool Demo { get; set; }
    public int Status { get; set; }
    public string Error { get; set; }
    public DateTimeOffset? CreateTime { get; set; }
    public DateTimeOffset? ExecuteTime { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

public class RobotCalculations
{
    public int TotalCount { get; set; }
    public int ProfitCount { get; set; }
    public int StoplossCount { get; set; }
    public int OpenCount { get; set; }
    public decimal ProfitPerc { get; set; }
    public decimal StoplossPerc { get; set; }
    public decimal ProfitTotal { get; set; }
    public decimal StoplossTotal { get; set; }
    public decimal? OpenTotal { get; set; }
    public decimal? TotalProfit { get; set; }
    public long? TimeStart { get; set; }
    public long? TimeEnd { get; set; }
}

public enum RobotCalculationsTarget
{
    Common,
    Current,
}
