using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardCallbackDto
{
    public Guid Id { get; set; }
    public string EventId { get; set; }
    public Guid? CardId { get; set; }
    public string EventType { get; set; }
    public decimal? Amount { get; set; }
    public string CurrencyCode { get; set; }
    public string MerchantName { get; set; }
    public DateTimeOffset DateReceived { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardCallbackDto)}(eventId:{EventId}, type:{EventType}, amount:{Amount} {CurrencyCode}, cardId:{CardId})";
}
