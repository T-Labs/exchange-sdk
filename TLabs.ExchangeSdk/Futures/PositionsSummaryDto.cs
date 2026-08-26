#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class PositionsSummaryDto
{
    public long FuturesAccountId { get; set; }
    public decimal Balance { get; set; }
    public string BalanceCurrency { get; set; }
    public decimal Equity => Math.Round(Balance + UnrealizedPnl, FuturesCurrencyConst.USDT_DECIMALS);
    public decimal UsedMargin { get; set; }
    public decimal UnrealizedPnl { get; set; }
    public decimal RealizedPnl { get; set; }
    public decimal TotalPnl => Math.Round(RealizedPnl + UnrealizedPnl, FuturesCurrencyConst.USDT_DECIMALS);
    public decimal FreeMargin => Math.Max(0, Math.Round(Equity - UsedMargin, FuturesCurrencyConst.USDT_DECIMALS));

    public decimal MarginLevel => Math.Round(UsedMargin, FuturesCurrencyConst.USDT_DECIMALS) > 0
        ? Math.Round(Math.Round(Equity, FuturesCurrencyConst.USDT_DECIMALS) / Math.Round(UsedMargin,
            FuturesCurrencyConst.USDT_DECIMALS) * 100, 2)
        : 0;
}
