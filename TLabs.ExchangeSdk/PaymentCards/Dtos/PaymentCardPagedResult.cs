using System.Collections.Generic;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

/// <summary>
/// Generic paged result for admin listing endpoints.
/// </summary>
public class PaymentCardPagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
}

/// <summary>
/// Request to block a payment card from the admin panel.
/// </summary>
public class BlockPaymentCardDto
{
    public string Reason { get; set; }
}
