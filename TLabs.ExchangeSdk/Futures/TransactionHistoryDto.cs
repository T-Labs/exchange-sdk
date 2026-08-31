#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class TransactionHistoryDto
{
    public long Id { get; set; }
    public long FuturesAccountId { get; set; }
    public long? TradeId { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
    public TransactionHistoryType TransactionHistoryType { get; set; }
}
