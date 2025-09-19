namespace TLabs.ExchangeSdk.TradingInnerBot;

public class LiquidityAlgorithmSettings
{
    public string CurrencyPairCode { get; set; }
    public bool IsActive { get; set; }
    public decimal OrderSizeFrom { get; set; }
    public decimal OrderSizeTo { get; set; }
    public int OrdersCount { get; set; } = 2;
    public decimal SpreadBetweenOrdersFrom { get; set; }
    public decimal SpreadBetweenOrdersTo { get; set; }
    public bool IsAutoRecreatingEnabled { get; set; }
}
