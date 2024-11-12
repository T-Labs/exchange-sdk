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

    /// <summary>if true then PaymentCurrency is actually a second Exchange Currency</summary>
    public bool AreBothCurrenciesExchange { get; set; }

    /// <summary>ExchangeAmount * Price = PaymentAmount</summary>
    public decimal Price { get; set; }

    /// <summary>Order amount in crypto, without fee</summary>
    public decimal TotalExchangeAmount { get; set; }

    /// <summary>Order amount in PaymentCurrency</summary>
    public decimal TotalPaymentAmount { get; set; }

    public decimal FilledExchangeAmount { get; set; }

    /// <summary>
    /// Fee amount in crypto, added on top of TotalExchangeAmount when freezing.
    /// For IsBuyingOnExchange=true it is always 0.
    /// </summary>
    public decimal TotalFeeAmount { get; set; }

    /// <summary>Min possible amount of a single Deal in Crypto</summary>
    public decimal MinDealAmount { get; set; }

    /// <summary>Max possible amount of a single Deal in Crypto</summary>
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

    public string CurrencyPairCode => $"{PaymentCurrencyCode}_{ExchangeCurrencyCode}";

    public override string ToString() =>
        $"{nameof(Order)}({CurrencyPairCode}, {(IsBuyingOnExchange ? "buy" : "sell")}" +
        $"Price:{Price}, TotalAmount:{TotalExchangeAmount}, Fee:{TotalFeeAmount}, RequisitesCount:{Requisites?.Count}, " +
        $"user:{UserId}), OrderStatus:{Status}";
}

public enum OrderStatus
{
    Active = 10,
    Closed = 20,
    ClosedCryptoUnfrozen = 30,
}
