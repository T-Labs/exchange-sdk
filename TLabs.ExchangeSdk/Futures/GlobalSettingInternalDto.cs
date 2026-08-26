namespace TLabs.ExchangeSdk.Futures;

using System.Collections.Generic;

public class GlobalSettingInternalDto
{
    public int MaxFuturesAccountsCount { get; set; }
    public int MaxLeverage { get; set; }
    public List<string> AvailableAccountCurrencies { get; set; }
    public LiquidityMirrorSettings LiquidityMirrorSettings { get; set; }
    public CopyTradingSettings CopyTradingSettings { get; set; }
}
