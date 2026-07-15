namespace TLabs.ExchangeSdk.Users;

public class ChangeEmailDto
{
    public string NewEmail { get; set; }

    /// <summary>Identity of the admin who changed the email</summary>
    public string UpdatedBy { get; set; }
}
