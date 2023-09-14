using RabbitMQ.Client;
using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class OrderRequest
{
    public string UserId { get; set; }
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
