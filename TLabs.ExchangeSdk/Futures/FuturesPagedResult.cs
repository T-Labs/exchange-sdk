namespace TLabs.ExchangeSdk.Futures;

using System.Collections.Generic;

/// <summary>
/// Wire-контракт пагинации Stock.Futures (только totalCount + items). Не PagedList из
/// DotnetHelpers: тот 1-based (фьючерсы 0-based), а его TotalPages при PageSize=0 даёт int.MinValue.
/// </summary>
public class FuturesPagedResult<T>
{
    public int TotalCount { get; set; }
    public List<T> Items { get; set; }
}
