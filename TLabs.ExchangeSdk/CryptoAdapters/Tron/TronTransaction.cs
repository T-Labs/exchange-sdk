using System;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace TLabs.ExchangeSdk.CryptoAdapters.Tron;

public enum TransactionType
{
    Deposit = 0,
    DepositToGlobal = 1,
    Withdrawal = 10,
    Consolidation = 20,
    Freeze = 40, FreezeCancel = 41,
}

public enum TransactionStatus
{
    Pending = 0, // Sent to blockchain, not included in block yet
    Error = 10, // Error in blockchain
    ConfirmedInBlockchain = 15, // Confirmed in blockchain
    Confirmed = 20 // Saved in Depository
}

public class TronTransaction
{
    [Key]
    public string Hash { get; set; }

    public TransactionType Type { get; set; }

    public TransactionStatus Status { get; set; }

    public decimal Amount { get; set; }

    [Required]
    public string CurrencyCode { get; set; }

    public long? BlockNum { get; set; }

    [Required]
    public string FromAddressHash { get; set; }

    [Required]
    public string ToAddressHash { get; set; }

    /// <summary>
    /// Withdrawal is sent from Global, so we save UserId separately
    /// </summary>
    public string UserId { get; set; }

    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }

    public string ErrorText { get; set; }

    /// <summary>Optional comment by admins</summary>
    public string Comment { get; set; }

    #region Withdrawal fields

    public Guid? WithdrawalDepositoryTransactionId { get; set; }

    /// <summary>
    /// true if it's not a user's withdrawal but cold wallet transfer
    /// </summary>
    public bool WithdrawalToColdWallet { get; set; } = false;

    #endregion Withdrawal fields

    #region Freezing fields

    /// <summary>For Energy or Bandwidth</summary>
    public bool FreezeIsBandwidth { get; set; } = false;

    public bool FreezeIsCanceled { get; set; } = false;

    /// <summary>Not related to exchange operation, delegated by Admin to any address he wants</summary>
    public bool ForExternalAddress { get; set; }

    #endregion Freezing fields

    public override string ToString() => $"{Type}(Hash:{Hash}, status:{Status}, Block:{BlockNum}, " +
        $"amount:{Amount} {CurrencyCode}, createdAt:{DateCreated}, from:{FromAddressHash}, to:{ToAddressHash})";
}
