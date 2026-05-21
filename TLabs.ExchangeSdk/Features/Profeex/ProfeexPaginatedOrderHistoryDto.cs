using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexPaginatedOrderHistoryDto
{
    public List<ProfeexOrderHistoryDto> Items { get; set; } = new();

    public long Total { get; set; }

    public int Page { get; set; }

    public int Size { get; set; }

    public int Pages { get; set; }

    public bool HasNext { get; set; }

    public bool HasPrevious { get; set; }
}
