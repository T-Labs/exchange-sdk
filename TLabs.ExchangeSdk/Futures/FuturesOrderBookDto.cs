namespace TLabs.ExchangeSdk.Futures;

using System.Collections.Generic;

public class FuturesOrderBookDto
{
    public string CurrencyPairCode { get; set; }
    public List<OrderBookItemDto> Asks { get; set; }
    public List<OrderBookItemDto> Bids { get; set; }
}
