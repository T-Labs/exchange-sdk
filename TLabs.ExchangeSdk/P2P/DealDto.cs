using System;

namespace TLabs.ExchangeSdk.P2P;

public record DealDto
{
    public Guid OrderId { get; set; }
    public string PaymentMethodCurrencyCode { get; set; }

    public string DealUserId { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset? DatePaymentSystemSent { get; set; }
    public DateTimeOffset? DateCryptoReleased { get; set; }
    public DateTimeOffset? DateFinished { get; set; }
}
