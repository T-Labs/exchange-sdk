using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.P2P;

public class OrderCreateDto
{
    public string UserId { get; set; }

    /// <summary> Buying on the exchange from a payment system or selling from the exchange </summary>
    public bool IsBuyingOnExchange { get; set; }

    public string ExchangeCurrencyCode { get; set; }

    public string PaymentCurrencyCode { get; set; }

    public List<Guid> RequisiteIds { get; set; }

    public decimal Price { get; set; }

    public decimal TotalOrderAmount { get; set; }

    public decimal MinDealAmount { get; set; }

    public decimal MaxDealAmount { get; set; }

    public string Description { get; set; }

    public int MaxTimeMinutes { get; set; }
    public bool IsKYCPassed { get; set; }
    public int MinDaysSinceRegistration { get; set; }
    public int MinOrdersRequired { get; set; }
    public int MinOrderCompletionRate { get; set; }

    public override string ToString() => $"{nameof(OrderCreateDto)}({ExchangeCurrencyCode}-{PaymentCurrencyCode}, " +
                                         $"RequisitesCount:{RequisiteIds?.Count} user:{UserId})";
}
