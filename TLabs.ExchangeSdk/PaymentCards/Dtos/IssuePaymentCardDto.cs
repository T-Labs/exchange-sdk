namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class IssuePaymentCardDto
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public int TemplateId { get; set; }
    public string DialCode { get; set; }
    public string PhoneNumber { get; set; }
    public decimal DepositAmount { get; set; } = 0;
    public string RecipientName { get; set; }
    public string CountryCode { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string AddressLine { get; set; }
    public PaymentCardKycDto Kyc { get; set; }

    public override string ToString() =>
        $"{nameof(IssuePaymentCardDto)}(userId:{UserId}, email:{Email}, template:{TemplateId}, deposit:{DepositAmount})";
}
