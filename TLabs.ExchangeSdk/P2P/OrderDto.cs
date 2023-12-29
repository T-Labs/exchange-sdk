using System;

namespace TLabs.ExchangeSdk.P2P;

public class OrderDto
{
    public string UserId { get; set; }

    /// <summary> Buying on the exchange from a payment system or selling from the exchange </summary>
    public bool IsBuyingOnExchange { get; set; }

    public string ExchangeCurrencyCode { get; set; }

    public decimal Price { get; set; }

    public decimal TotalOrderAmount { get; set; }

    public decimal MinDealAmount { get; set; }

    public decimal MaxDealAmount { get; set; }

    public DateTimeOffset? DateClosed { get; set; }

    public string Description { get; set; }

    public int MaxTimeMinutes { get; set; }
}
