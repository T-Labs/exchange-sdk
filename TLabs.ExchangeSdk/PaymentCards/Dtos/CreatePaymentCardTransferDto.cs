using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class CreatePaymentCardTransferDto
{
    public string UserId { get; set; }
    public decimal Amount { get; set; }
    public PaymentCardTransferDirection Direction { get; set; }

    public override string ToString() =>
        $"{nameof(CreatePaymentCardTransferDto)}(userId:{UserId}, direction:{Direction}, amount:{Amount})";
}
