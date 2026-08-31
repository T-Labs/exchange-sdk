#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class OrderDto
{
    public string Id { get; set; } = null!;
    public DateTime CreateTimestamp { get; set; }
    public DateTime UpdateTimestamp { get; set; }
    public decimal? Price { get; set; }
    public decimal? AvgClosePrice { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyPairCode { get; set; } = null!;
    public decimal? TakeProfit { get; set; }
    public decimal? StopLoss { get; set; }

    /// <summary>Цена триггера stop-limit ордера; null — обычный ордер</summary>
    public decimal? StopPrice { get; set; }

    /// <summary>Триггер stop-limit сработал, ордер ждёт исполнения как обычная лимитка</summary>
    public bool IsTriggered { get; set; }

    public decimal RealizedPnl { get; set; }
    public decimal Leverage { get; set; }
    public bool IsLong { get; set; }
    public bool IsMarket { get; set; }
    public decimal LiquidationPrice { get; set; }
    public decimal Filled { get; set; }
    public decimal Fee { get; set; }
    public string? FeeAsset { get; set; }
    public decimal AmountInPosition { get; set; }
    public FuturesOrderStatus FuturesOrderStatus { get; set; }
    public string UserId { get; set; } = null!;
    public string? ClientOrderId { get; set; }
    public decimal FundingFee { get; set; }
    public decimal InitialMargin { get; set; }
    public decimal CurrentMargin { get; set; }
    public decimal UnRealizedPnl { get; set; }
    public decimal UnRealizedPnlPercentage { get; set; }
    public decimal TotalPnlPercentage { get; set; }
    public decimal Roe { get; set; }
    public decimal ClosedProfit { get; set; }
    public bool IsCopyTrading { get; set; }
    public CopyTradingOrderDetails? CopyTradingDetails { get; set; }
}

public class CopyTradingOrderDetails
{
    public long? CopyMasterFuturesAccountId { get; set; }
    public string? CopyMasterName { get; set; }
    public string? CopyMasterOrderId { get; set; }
}
