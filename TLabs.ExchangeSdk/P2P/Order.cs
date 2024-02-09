using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.P2P;

public class Order
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public bool IsBuyingOnExchange { get; set; }

    [Required]
    public string ExchangeCurrencyCode { get; set; }

    [Required]
    public string PaymentCurrencyCode { get; set; }

    public List<PaymentSystem> PaymentSystems { get; set; }
    public decimal Price { get; set; }
    public decimal TotalOrderAmount { get; set; }
    public decimal MinDealAmount { get; set; }
    public decimal MaxDealAmount { get; set; }
    public OrderStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateClosed { get; set; }

    [Required]
    public string Description { get; set; }

    public int MaxTimeMinutes { get; set; }

    public long DisplayId { get; set; }
    public bool IsKYCPassed { get; set; }
    public int MinDaysSinceRegistration { get; set; }
    public int MinOrdersRequired { get; set; }
    public int MinOrderCompletionRate { get; set; }
    public List<Deal> Deals { get; set; }

    [NotMapped]
    public string UserNickname { get; set; }
}

public enum OrderStatus
{
    Active = 10,
    Closed = 20,
}
