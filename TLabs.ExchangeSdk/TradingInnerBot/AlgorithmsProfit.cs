using System;

namespace TLabs.ExchangeSdk.TradingInnerBot;

public class AlgorithmsProfit
{
    public int Id { get; set; }
    public string CurrencyPairCode { get; set; }
    public decimal Value { get; set; }
    public DateTimeOffset Date { get; set; }
}
