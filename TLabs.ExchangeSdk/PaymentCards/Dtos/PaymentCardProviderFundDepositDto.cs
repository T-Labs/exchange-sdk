using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardProviderFundDepositDto
{
    public Guid Id { get; set; }
    public string AdminUserId { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Amount { get; set; }
    public string Comment { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardProviderFundDepositDto)}(id:{Id}, admin:{AdminUserId}, amount:{Amount} {CurrencyCode})";
}
