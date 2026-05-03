using System;

namespace TLabs.ExchangeSdk.TradingRobots.Models;

public class RobotDto
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string Config { get; set; }
    public RobotWorkStatus Work { get; set; }
    public int Lots { get; set; }
    public string Markets { get; set; }
    public bool Demo { get; set; }
    public long? TimeStart { get; set; }
    public decimal? Profit { get; set; }
    public decimal? ProfitPerc { get; set; }
}

public class CreateRobotRequest
{
    /// <summary>"cf" or "rsi"</summary>
    public string Type { get; set; }

    /// <summary>For cf: "usdt:conservative" / "usdt:moderate" / "usdt:risky". For rsi: "full"</summary>
    public string SecondType { get; set; }
}

public class CreateRobotResult
{
    public long Id { get; set; }
}

public class EditRobotSettingsRequest
{
    public long ExchangeId { get; set; }
    public decimal TotalBalance { get; set; }
    public string MainCoin { get; set; }
    /// <summary>JSON array of pairs, e.g. ["BTC/USDT","ETH/USDT"]</summary>
    public string Markets { get; set; }
    public int Lots { get; set; }
    /// <summary>JSON config: { robotBuyMAlot, leverage, risk_perc, risk_status }</summary>
    public string Config { get; set; }
    public bool StartRobot { get; set; }
}

public class ToggleRobotRequest
{
    public RobotWorkStatus Status { get; set; }
}
