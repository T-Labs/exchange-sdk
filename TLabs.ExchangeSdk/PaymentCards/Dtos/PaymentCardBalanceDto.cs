using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardBalanceDto
{
    public Guid CardId { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyCode { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardBalanceDto)}(cardId:{CardId}, balance:{Balance} {CurrencyCode})";
}
