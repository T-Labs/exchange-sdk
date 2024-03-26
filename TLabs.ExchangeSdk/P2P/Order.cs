using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TLabs.ExchangeSdk.P2P.Deals;

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

    /// <summary>cryptoAmount * price = fiatAmount</summary>
    public decimal Price { get; set; }

    /// <summary>All amounts are in crypto</summary>
    public decimal TotalOrderAmount { get; set; }

    public decimal MinDealAmount { get; set; }
    public decimal MaxDealAmount { get; set; }
    public OrderStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateClosed { get; set; }
    public DateTimeOffset? DateProcessEnded { get; set; }

    [Required]
    public string Description { get; set; }

    public int MaxTimeMinutes { get; set; }

    public long DisplayId { get; set; }
    public bool IsKYCPassed { get; set; }
    public int MinDaysSinceRegistration { get; set; }
    public int MinOrdersRequired { get; set; }
    public int MinOrderCompletionRate { get; set; }

    public List<Requisite> Requisites { get; set; }

    public List<Deal> Deals { get; set; }

    [NotMapped]
    public string UserNickname { get; set; }

    [NotMapped]
    public OrderUserInfo UserInfo { get; set; }

    public override string ToString() =>
        $"{nameof(Order)}({ExchangeCurrencyCode}-{PaymentCurrencyCode}, {(IsBuyingOnExchange ? "buy" : "sell")}" +
        $"Price:{Price}, TotalAmount:{TotalOrderAmount}, RequisitesCount:{Requisites?.Count}, user:{UserId}), OrderStatus:{Status}";
}

public enum OrderStatus
{
    Active = 10,
    Closed = 20,
    ClosedCryptoUnfrozen = 30,
}
