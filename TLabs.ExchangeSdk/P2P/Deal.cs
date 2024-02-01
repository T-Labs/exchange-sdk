using System;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class Deal
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public int PaymentSystemId { get; set; }
    public string DealUserId { get; set; }

    public decimal Price { get; set; }

    /// <summary>Amount in crypto currency</summary>
    public decimal CryptoAmount { get; set; }

    /// <summary>Amount in fiat currency</summary>
    public decimal FiatAmount => (CryptoAmount * Price).RoundDown(2);

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
