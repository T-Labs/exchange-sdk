#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class FuturesAccountDto
{
    public long Id { get; set; }
    public string UserId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Balance { get; set; }
    public decimal BlockedCopyTradingBalance { get; set; }
    public decimal UsedMargin { get; set; }
    public int Leverage { get; set; }
    public decimal Equity => Math.Round(Balance + UnrealizedPnl, FuturesCurrencyConst.USDT_DECIMALS);
    public decimal UnrealizedPnl { get; set; }
    public decimal FreeMargin => Math.Max(0, Math.Round(Equity - UsedMargin, FuturesCurrencyConst.USDT_DECIMALS));
    public decimal MarginLevel => UsedMargin > 0 ? Math.Round(Equity / UsedMargin * 100, 2) : 0;
    public bool IsLiquidated { get; set; }
    public DateTime? LiquidationTimestamp { get; set; }
    public string CurrencyCode { get; set; } = null!;
    public FuturesAccountType AccountType { get; set; }
}
