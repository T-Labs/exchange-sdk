using System;
using TLabs.ExchangeSdk.Trading;

namespace TLabs.ExchangeSdk.LiquidityImport
{
    /// <summary>Order from external exchange orderbook</summary>
    public class OrderbookOrder : OrderBase, ICloneable
    {
        public string TradingOrderId { get; set; }

        public bool IsMarket { get; set; }

        public static string GetUserId(Exchange exchange) => exchange.ToString();

        public object Clone() => MemberwiseClone();
    }
}
