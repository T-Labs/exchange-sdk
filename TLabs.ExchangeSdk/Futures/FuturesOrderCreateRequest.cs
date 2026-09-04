#nullable enable
namespace TLabs.ExchangeSdk.Futures;

public class FuturesOrderCreateRequest
{
    public bool IsMarket { get; set; }
    public bool IsLong { get; set; }
    public int Leverage { get; set; }
    public decimal? Price { get; set; }
    public decimal? StopLoss { get; set; }
    public decimal? TakeProfit { get; set; }

    /// <summary>
    /// Цена триггера stop-limit ордера. Только для лимитных ордеров (IsMarket=false).
    /// Long: срабатывает при росте цены до StopPrice (требуется StopPrice выше текущего ask);
    /// short: при падении до StopPrice (ниже текущего bid). После срабатывания ордер
    /// исполняется как обычная лимитка по Price.
    /// </summary>
    public decimal? StopPrice { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyPairCode { get; set; } = null!;
    public string? UserId { get; set; }
    public OrderAmountType OrderAmountType { get; set; } = OrderAmountType.Crypto;
    public long FuturesAccountId { get; set; }

    public long? FromCopyMasterAccountId { get; set; }
    public string? FromCopyMasterOrderId { get; set; }

    public string? ClientOrderId { get; set; }
}
