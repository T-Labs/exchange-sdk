namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class IssuePaymentCardDto
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string CurrencyCode { get; set; }
    public int TemplateId { get; set; }
    public string DialCode { get; set; }
    public string PhoneNumber { get; set; }
    public decimal DepositAmount { get; set; } = 0;
    public string PrintedCardNumber { get; set; }
    public string Pin { get; set; }
    public PaymentCardKycDto Kyc { get; set; }

    public override string ToString() =>
        $"{nameof(IssuePaymentCardDto)}(userId:{UserId}, currency:{CurrencyCode}, email:{Email}, template:{TemplateId}, deposit:{DepositAmount})";
}
