namespace TLabs.ExchangeSdk.Verification;

public class VerificationUpdateDto
{
    public UserVerificationStage Stage { get; set; }
    public StatusVerificationUser Status { get; set; }
    public string Message { get; set; }
}
