using System;

namespace TLabs.ExchangeSdk.Trading
{
    public class ResponseOHLC
    {
        /// <summary>
        /// Date time
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Opden
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Max
        /// </summary>
        public decimal Max { get; set; }

        /// <summary>
        /// Min
        /// </summary>
        public decimal Min { get; set; }

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
