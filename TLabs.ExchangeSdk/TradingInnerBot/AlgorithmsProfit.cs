using System;

namespace TLabs.ExchangeSdk.TradingInnerBot;

public class AlgorithmsProfit
{
    public int Id { get; set; }
    public string CurrencyPairCode { get; set; }
    public decimal TradingBotProfit { get; set; }
    public decimal LiquidityBotProfit { get; set; }
    public DateTimeOffset Date { get; set; }
    public decimal TotalProfit => TradingBotProfit + LiquidityBotProfit;
}
