using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Verification;

public class VerificationCard
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public VerificationUser VerificationUser { get; set; }
    public StatusVerificationCard Status { get; set; } = StatusVerificationCard.Success;
    public string Name { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string PhotoCardFrontSide { get; set; }
    public string PhotoCardBackSide { get; set; }
    public DateTimeOffset? DateCreate { get; set; }
    public DateTimeOffset? DateVerification { get; set; }

    /// <summary> Administrator's comment when changing the profile status </summary>
    public string StatusMessage { get; set; }
}

public enum StatusVerificationCard
{
    /// <summary>Not fully filled yet</summary>
    OnFilling = 0,

    /// <summary>Being processed</summary>
    OnVerification = 1,

    Failed,
    Success
}
