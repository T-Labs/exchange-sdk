namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class ActivatePhysicalPaymentCardDto
{
    public string UserId { get; set; }
    public string PrintedCardNumber { get; set; }
    public string Pin { get; set; }
}
