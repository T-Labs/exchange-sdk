#nullable enable
namespace TLabs.ExchangeSdk.Futures;

using System;
using System.Collections.Generic;

public class FuturesOrdersHistoryRequest
{
    public string? UserId { get; set; }
    public bool IncludeAllUsers { get; set; }
    public string? CurrencyPair { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 100;
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<FuturesOrderStatus>? Statuses { get; set; }
    public long? FuturesAccountId { get; set; }
}
