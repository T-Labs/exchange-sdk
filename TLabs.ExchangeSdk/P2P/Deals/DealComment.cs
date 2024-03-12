using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.P2P.Deals;

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

    public bool IsAnonymously { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public bool IsDelete { get; set; }

    [NotMapped]
    public string UserNickname { get; set; }
}
