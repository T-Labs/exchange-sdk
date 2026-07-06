namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardKycDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string DateOfBirth { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardKycDto)}(firstName:{FirstName}, lastName:{LastName}, gender:{Gender}, dob:{DateOfBirth})";
}
