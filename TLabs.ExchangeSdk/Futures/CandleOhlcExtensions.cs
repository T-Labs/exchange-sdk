namespace TLabs.ExchangeSdk.Futures;

using System.Collections.Generic;
using System.Linq;
using TLabs.ExchangeSdk.Trading;

/// <summary>Конвертация свечей фьючерсов в формат маркет-даты спота</summary>
public static class CandleOhlcExtensions
{
    public static ResponseOHLC ToResponseOhlc(this CandleDto candle) => new()
    {
        Date = candle.OpenTimestamp,
        Open = candle.OpenPrice,
        Max = candle.MaxPrice,
        Min = candle.MinPrice,
        Close = candle.ClosePrice,
        Volume = candle.Volume,
        VolumeBase = candle.VolumeBase,
    };

    public static List<ResponseOHLC> ToResponseOhlc(this IEnumerable<CandleDto> candles) =>
        candles.Select(c => c.ToResponseOhlc()).ToList();
}
