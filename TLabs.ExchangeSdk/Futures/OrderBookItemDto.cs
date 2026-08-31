namespace TLabs.ExchangeSdk.Futures;

using System.Collections.Generic;

public class OrderBookItemDto
{
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}

public struct IndexOrderBookItemDto
{
    public decimal PriceChange { get; set; }
    public decimal UsdtVolume { get; set; }
}

public class OrderBookDto
{
    public List<OrderBookItemDto> Asks { get; set; }
    public List<OrderBookItemDto> Bids { get; set; }
}
