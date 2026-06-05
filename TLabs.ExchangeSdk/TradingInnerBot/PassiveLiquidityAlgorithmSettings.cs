namespace TLabs.ExchangeSdk.TradingInnerBot;

public class PassiveLiquidityAlgorithmSettings
{
    public string CurrencyPairCode { get; set; }

    public bool IsActive { get; set; }

    public decimal OrderSizeFrom { get; set; }

    public decimal OrderSizeTo { get; set; }

    public int OrdersCount { get; set; } = 2;

    public decimal SpreadBetweenOrdersFrom { get; set; }

    public decimal SpreadBetweenOrdersTo { get; set; }

    public decimal PriceOffset { get; set; }

    public decimal RequiredVolume { get; set; }

    /// <summary>Minimum number of live bot orders to maintain per pair (both sides), to guarantee orderbook depth (e.g. for CoinGecko)</summary>
    public int MinLiveOrdersCount { get; set; } = 12;

    /// <summary>If true, already standing real orders (User/LiquidityImport) are counted towards target depth so the bot doesn't create redundant orders on top of them</summary>
    public bool CountForeignLiveOrders { get; set; }
}
