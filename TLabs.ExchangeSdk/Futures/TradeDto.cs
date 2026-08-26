#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

using Newtonsoft.Json;

public class TradeDto
{
    public long Id { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyPairCode { get; set; }
    public bool IsLong { get; set; }
    public string UserId { get; set; }

    [JsonIgnore]
    public bool IsFakeDealsBot { get; set; }

    public decimal RealizedPnl { get; set; }
    public decimal Fees { get; set; }

    public decimal ClosedProfit => RealizedPnl + Math.Abs(Fees);

    public TradeType TradeType { get; set; }

    // public decimal TradeResult { get; set; }
    //public TradeType TradeType { get; set; }
    public string OrderId { get; set; }
    public long FuturesAccountId { get; set; }
    public OrderSide OrderSide { get; set; }

    /// <summary>Leverage of the source order (copied from Order.Leverage at query time).</summary>
    public decimal Leverage { get; set; }

    /// <summary>
    /// Snapshot of the source order's CopyOrder.CopySlaveFuturesAccountId
    /// stamped at trade-enqueue time so <see cref="Workers.Notifications.DealNotificationWorker"/> doesn't
    /// race against <c>OrdersCache.RemovePositionOrder</c> on close-side trades.
    /// </summary>
    public long? CopySlaveFuturesAccountId { get; set; }

    /// <summary>Companion to <see cref="CopySlaveFuturesAccountId"/> — the master side of the copy pair.</summary>
    public long? CopyMasterFuturesAccountId { get; set; }

    public TradeDto RemoveUserId()
    {
        UserId = string.Empty;
        return this;
    }

    /// <summary>
    /// То же для читателей, которым отдают объект из TradesCache: там DTO общий,
    /// вычищать userId на месте нельзя — сломается фильтр владельческой ленты (D37).
    /// </summary>
    public TradeDto WithoutUserId() => ((TradeDto)MemberwiseClone()).RemoveUserId();
}
