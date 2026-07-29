using System.Collections.Generic;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardPagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
}
