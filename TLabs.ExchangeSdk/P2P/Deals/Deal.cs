using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.P2P.Chats;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class Deal
{
    [Key]
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public Guid RequisiteId { get; set; }
    public Requisite Requisite { get; set; }

    [Required]
    public string DealUserId { get; set; }

    public decimal Price { get; set; }

    /// <summary>Amount in crypto currency</summary>
    public decimal CryptoAmount { get; set; }

    /// <summary>Amount in fiat currency</summary>
    public decimal FiatAmount => (CryptoAmount * Price).RoundDown(2);

    public DealStatus Status { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DatePaymentSystemSent { get; set; }
    public DateTimeOffset? DatePaymentSystemConfirmed { get; set; }
    public DateTimeOffset? DateCanceled { get; set; }

    /// <summary> For CanceledCryptoUnfrozen status after Crypto Unfreeze and CryptoRealese status after FinishDeal</summary>
    public DateTimeOffset? DateProcessEnded { get; set; }

    public long DisplayId { get; set; }
    public List<DealComment> Comments { get; set; }
    public decimal CryptoAmountInUsdt { get; set; }
    public List<ChatMessage> ChatMessages { get; set; }
    public List<DealAppeal> DealAppeals { get; set; }
    public DealCancelDispute DealCancelDispute { get; set; }

    [NotMapped]
    public string UserNickname { get; set; }

    public override string ToString() =>
        $"{nameof(Deal)}(OrderId:{OrderId}, Crypto:{CryptoAmount} {Order?.ExchangeCurrencyCode}, " +
        $"Fiat:{FiatAmount} {Order?.PaymentCurrencyCode}, DealUserId:{DealUserId}, DealStatus:{Status})";
}

public enum DealStatus
{
    CreatedAwaitingPaymentSystem = 10,
    PaymentSystemSent = 20,
    PaymentSystemConfirmed = 40,
    CryptoReleased = 50,
    Canceled = 60,
    CanceledCryptoUnfrozen = 80,
}
