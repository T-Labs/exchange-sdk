namespace TLabs.ExchangeSdk.Futures;

public class LiquidityMirrorSettings
{
    public bool LiquidityMirrorEnabledByDefault { get; set; }
    public bool AutoEnableMirror { get; set; }
    public int AutoEnableIntervalInMinutes { get; set; }
    public decimal AutoEnableMinInOutDiff { get; set; }
}

public class CopyTradingSettings
{
    public bool Enabled { get; set; }
    public bool ShowTopMasterTraders { get; set; } = true;
    public bool DailyPicksPopupEnabled { get; set; } = true;
}
