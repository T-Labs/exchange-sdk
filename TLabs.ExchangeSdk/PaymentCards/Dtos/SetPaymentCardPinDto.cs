namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class SetPaymentCardPinDto
{
    public string Pin { get; set; }

    public override string ToString() =>
        $"{nameof(SetPaymentCardPinDto)}(pin:***)";
}
