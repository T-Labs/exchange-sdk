using System;
using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public PaymentCardStatus Status { get; set; }
    public string CurrencyCode { get; set; }
    public string MaskedPan { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardDto)}(id:{Id}, userId:{UserId}, status:{Status}, currency:{CurrencyCode})";
}
