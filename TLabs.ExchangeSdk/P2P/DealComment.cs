using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class DealComment
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid DealId { get; set; }

    public Deal Deal { get; set; }

    [Required]
    public string FromUserId { get; set; }

    [Required]
    public string ToUserId { get; set; }

    public bool IsPositive { get; set; }

    [Required]
    public string Comment { get; set; }

    public DateTimeOffset DateCreated { get; set; }
}
