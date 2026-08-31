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
    public string CurrencyPairCode { get; set; } = null!;
    public bool IsLong { get; set; }
    public string UserId { get; set; } = null!;

    [JsonIgnore]
    public bool IsFakeDealsBot { get; set; }

    public decimal RealizedPnl { get; set; }
    public decimal Fees { get; set; }

    public decimal ClosedProfit => RealizedPnl + Math.Abs(Fees);

    public TradeType TradeType { get; set; }

    public string OrderId { get; set; } = null!;
    public long FuturesAccountId { get; set; }
    public OrderSide OrderSide { get; set; }

    /// <summary>Плечо исходного ордера на момент запроса</summary>
    public decimal Leverage { get; set; }

    /// <summary>Снимок copy-slave счёта исходного ордера на момент постановки сделки в очередь</summary>
    public long? CopySlaveFuturesAccountId { get; set; }

    /// <summary>Мастер-сторона копи-пары, снимается вместе с <see cref="CopySlaveFuturesAccountId"/></summary>
    public long? CopyMasterFuturesAccountId { get; set; }

    public TradeDto RemoveUserId()
    {
        UserId = string.Empty;
        return this;
    }

    /// <summary>Копия без userId — для общих DTO из кэша, которые нельзя чистить на месте</summary>
    public TradeDto WithoutUserId() => ((TradeDto)MemberwiseClone()).RemoveUserId();
}
