using System;

namespace TLabs.ExchangeSdk.P2P;

public class Deal
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public int PaymentSystemId { get; set; }
    public string PaymentMethodCurrencyCode { get; set; }
    public string DealUserId { get; set; }

    /// <summary>Crypto amount</summary>
    public decimal Amount { get; set; }

    public decimal Price { get; set; }
    public DealStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DatePaymentSystemSent { get; set; }
    public DateTimeOffset? DateCryptoReleased { get; set; }
    public DateTimeOffset? DateProcessEnded { get; set; }
    public Order Order { get; set; }
}

public enum DealStatus
{
    CreatedAwaitingPaymentSystem = 10,
    PaymentSystemSentAwaitingCryptoRelease = 20,
    CryptoReleased = 30,
    Completed = 40,
    Canceled = 50,
    Appealed = 60,
}
