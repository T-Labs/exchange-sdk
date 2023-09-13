using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace TLabs.ExchangeSdk.P2P;

public class Order
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public bool IsBuyingOnExchange { get; set; }
    public string ExchangeCurrencyCode { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; }
    public decimal Price { get; set; }
    public decimal TotalOrderAmount { get; set; }
    public decimal MinDealAmount { get; set; }
    public decimal MaxDealAmount { get; set; }
    public OrderStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateClosed { get; set; }
    public string Description { get; set; }
    public int MaxTimeMinutes { get; set; }
}
public enum OrderStatus
{
    Active = 10,
    Closed = 20,
}
