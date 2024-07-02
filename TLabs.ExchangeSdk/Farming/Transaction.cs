using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class Transaction
{

    [Key]
    public Guid Id { get; set; }

    public long RecipientUserId { get; set; }
    public long TenantId { get; set; }
    public decimal Amount { get; set; }

    public long? ReferralUserId { get; set; }

    /// <summary> The depth of the level of the system /// </summary>
    public int? ReferralLevel { get; set; }

    public DateTimeOffset DateCreated { get; set; }


}
