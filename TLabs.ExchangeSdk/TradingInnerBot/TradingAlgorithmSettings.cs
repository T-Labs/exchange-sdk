namespace TLabs.ExchangeSdk.TradingInnerBot;

public class TradingAlgorithmSettings
{
    public string CurrencyPairCode { get; set; }
    public bool IsActive { get; set; }
    public decimal OrderRatio { get; set; }
    public TradingAlgorithmPeriod Period { get; set; }
    //order sizes
    public decimal SizeFrom { get; set; }
    public decimal SizeTo { get; set; }
}


public enum TradingAlgorithmPeriod
{
    Minute,
    Minute5,
}
