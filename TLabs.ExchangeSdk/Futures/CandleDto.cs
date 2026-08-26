namespace TLabs.ExchangeSdk.Futures;

using System;

public class CandleDto
{
    public string CurrencyPairCode { get; set; }
    public decimal OpenPrice { get; set; }
    public decimal ClosePrice { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal MinPrice { get; set; }
    public CandleTimePeriod CandleTimePeriod { get; set; }
    public decimal Volume { get; set; }

    public decimal VolumeBase { get; set; }
    public DateTime OpenTimestamp { get; set; }
    public DateTime CloseTimestamp { get; set; }
}

