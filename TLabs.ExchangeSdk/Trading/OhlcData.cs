using System;

namespace TLabs.ExchangeSdk.Trading
{
    public enum MarketDataItemRange
    {
        Year = 1, Month = 2, Day = 3, Hour4 = 4, Hour = 5, Minutes30 = 6, Minutes15 = 7, Minutes5 = 8, Minutes3 = 9, Minute = 10
    }

    /// <summary>
    /// OHLC type data to build japanese candlestick charts
    /// </summary>
    public class OhlcData
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>CurrencyPair code</summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Date time
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Date time range
        /// </summary>
        public MarketDataItemRange Range { get; set; }

        /// <summary>
        /// Min value
        /// </summary>
        public decimal Min { get; set; }

        /// <summary>
        /// Max value
        /// </summary>
        public decimal Max { get; set; }

        /// <summary>
        /// Open
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Close
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Volume in base currency
        /// </summary>
        public decimal VolumeBase { get; set; }
    }
}
