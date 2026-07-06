using System;
using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardTransferDto
{
    public Guid Id { get; set; }
    public Guid CardId { get; set; }
    public string UserId { get; set; }
    public PaymentCardTransferDirection Direction { get; set; }
    public PaymentCardTransferStatus Status { get; set; }
    public PaymentCardTransferFailureReason FailureReason { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Amount { get; set; }
    public string ErrorMessage { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateCompleted { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardTransferDto)}(id:{Id}, {Direction}, {Status}, {Amount} {CurrencyCode}, cardId:{CardId})";
}
