using RabbitMQ.Client;
using System;

namespace TLabs.ExchangeSdk.P2P;

public class DealRequest
{
    public Guid OrderId { get; init; }
    public string PaymentMethodCurrencyCode { get; init; }
    public string DealUserId { get; init; }
    public DateTimeOffset? DatePaymentSystemSent { get; init; }
    public DateTimeOffset? DateCryptoReleased { get; init; }
    public DateTimeOffset? DateFinished { get; init; }
}
