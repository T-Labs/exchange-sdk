namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardKycDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string DateOfBirth { get; set; }
    public PaymentCardKycDataDto KycData { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardKycDto)}(firstName:{FirstName}, lastName:{LastName}, gender:{Gender}, dob:{DateOfBirth})";
}

public class PaymentCardKycDataDto
{
    public string CountryCode { get; set; }
    public string IdentificationType { get; set; }
    public string IdentificationNumber { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string AddressLine { get; set; }
    public string FrontImgBase64 { get; set; }
}
