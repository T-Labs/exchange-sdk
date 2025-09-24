namespace TLabs.ExchangeSdk.TradingInnerBot;

public class TradingAlgorithmSettings
{
    public string CurrencyPairCode { get; set; }
    public bool IsActive { get; set; }
    public decimal OrderRatio { get; set; }
    public TradingAlgorithmPeriod Period { get; set; }
    //order sizes
    public decimal AmountFrom { get; set; }
    public decimal AmountTo { get; set; }
}


public enum TradingAlgorithmPeriod
{
    Minute = 10,
    Minute5 = 20,
}
