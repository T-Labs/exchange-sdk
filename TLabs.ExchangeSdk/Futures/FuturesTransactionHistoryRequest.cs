#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;

public class FuturesTransactionHistoryRequest
{
    public string? UserId { get; set; }
    public long FuturesAccountId { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 100;
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public TransactionHistoryType? Type { get; set; }
}
