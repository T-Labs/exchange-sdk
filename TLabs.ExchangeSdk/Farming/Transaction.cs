using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class Transaction
{
    [Key]
    public Guid Id { get; set; }

    public long RecipientUserId { get; set; }
    public User RecipientUser { get; set; }

    public long TenantId { get; set; }
    public decimal Amount { get; set; }

    public long? ReferralUserId { get; set; }

    /// <summary> The depth of the level of the system /// </summary>
    public int? ReferralLevel { get; set; }

    public DateTimeOffset DateCreated { get; set; }
    public TransactionType TransactionType { get; set; }
}

public enum TransactionType
{
    Farming = 100,
    Daily = 200,
    Referral = 300,
    Task = 400,
    ImportBalance = 500,
    ReferralSignUpBonus = 600,
    MiniGame = 700,
}
