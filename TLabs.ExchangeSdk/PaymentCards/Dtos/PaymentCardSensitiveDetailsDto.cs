using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardSensitiveDetailsDto
{
    public Guid CardId { get; set; }

    public string Number { get; set; }

    public string Cvv { get; set; }

    public string ExpiryDate { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardSensitiveDetailsDto)}(cardId:{CardId}, number:<redacted>, cvv:<redacted>, expiryDate:<redacted>)";
}
