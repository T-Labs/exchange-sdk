using RabbitMQ.Client;
using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class OrderRequest
{
    public string UserId { get; init; }
    public bool IsBuyingOnExchange { get; init; }
    public string ExchangeCurrencyCode { get; init; }
    public decimal Price { get; init; }
    public decimal TotalOrderAmount { get; init; }
    public decimal MinDealAmount { get; init; }
    public decimal MaxDealAmount { get; init; }
    public DateTimeOffset? DateClosed { get; init; }
    public string Description { get; init; }
    public int MaxTimeMinutes { get; init; }
}
