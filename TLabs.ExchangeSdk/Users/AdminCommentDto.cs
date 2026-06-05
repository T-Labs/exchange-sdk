namespace TLabs.ExchangeSdk.Users;

public class AdminCommentDto
{
    /// <summary>Free-form note left by admins about the user</summary>
    public string Comment { get; set; }

    /// <summary>Identity of the admin who edited the comment</summary>
    public string UpdatedBy { get; set; }
}
