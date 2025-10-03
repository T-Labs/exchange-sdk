using System;

namespace TLabs.ExchangeSdk.CashExchanges;

public class CashExchangeSummary
{
    public DateTimeOffset Date { get; set; }
    public decimal PrevDayRemainsInUsdt { get; set; }

    public decimal TronlinkUsdtSum { get; set; }
    public decimal BlackUsdtSum { get; set; }
    public decimal UsdSum { get; set; }
    public decimal EurSum { get; set; }
    public decimal TrySum { get; set; }
    public decimal BybitRUSDTSum { get; set; }
    public decimal TronlinkTrxSum { get; set; }
    public decimal BlackTrxSum { get; set; }
    public decimal TrustUsdtSum { get; set; }
    public decimal TrustTrxSum { get; set; }

    /// <summary>Calculated in Admin</summary>
    public decimal SumOfUsdt { get; set; }
}
