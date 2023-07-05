using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Commissions;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class Withdrawal
    {
        [Key]
        public Guid Id { get; set; }

        public WithdrawalType WithdrawalType { get; set; }

        /// <summary>
        /// Only used with WithdrawalType.AdvCashBankCard
        /// </summary>
        public WithdrawalBankCard BankCard { get; set; }

        [Required]
        public int StatusId { get; set; }

        public virtual WithdrawalStatus Status { get; set; }

        public bool IsToColdWallet { get; set; }

        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Commission taken by exchange
        /// </summary>
        public CommissionValue CalculatedStockCommission { get; set; }

        public decimal ActualNetworkCommission { get; set; }

        public string NetworkCommissionCurrencyCode { get; set; }

        [Required]
        public string WithdrawalAddress { get; set; }

        public string WithdrawalAddressPublicKey { get; set; }

        public ClientType ClientType { get; set; }

        /// <summary>
        /// Withdrwing user id
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Transaction number in crypto system
        /// </summary>
        public string TxId { get; set; }

        /// <summary>
        /// Date withdrawal created
        /// </summary>
        public DateTimeOffset? DateTimeCreated { get; set; }

        /// <summary>
        /// Date withdrawal went to a cryptocurrency service
        /// </summary>
        public DateTimeOffset? DateTimeProcessed { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        /// <summary>Some coins have multiple adapters to choose</summary>
        [Required]
        public string AdapterCode { get; set; }

        /// <summary>
        /// Transaction number in depository
        /// </summary>
        public Guid RequestWithdrawalTransactionId { get; set; }

        /// <summary>
        /// text of withdrawal error
        /// </summary>
        public string ErrorText { get; set; }

        public string InternalRecepientUserId { get; set; }

        public ClientType InternalRecepientClientType { get; set; }

        /// <summary>Only used in cash withdrawals</summary>
        public string PublicId { get; set; } = null;

        public decimal CommissionInWithdrawalCurrency => Math.Min(
            (CalculatedStockCommission?.CurrencyCode == CurrencyCode ? CalculatedStockCommission.Amount : 0),
            Amount);

        public decimal AmountAfterCommission =>
            Math.Max(Amount - CommissionInWithdrawalCurrency, 0).RoundDown(CurrenciesCache.Digits);

        public override string ToString() => $"{nameof(Withdrawal)}(Id:{Id}, Status:{StatusId}, {Amount} {CurrencyCode} ({AdapterCode}), {ClientType} {UserId}, " +
            $"{(IsToColdWallet ? "ToColdWallet" : "")}, " +
            $"{(string.IsNullOrEmpty(TxId) ? "" : $"txId:{TxId}")}, " +
            $"{(CalculatedStockCommission == null ? "" : $"stock commission:{CalculatedStockCommission.Amount} {CalculatedStockCommission.CurrencyCode}")}, " +
            $"{(string.IsNullOrEmpty(InternalRecepientUserId) ? "" : $"recepient userId:{InternalRecepientUserId}")}, " +
            $"{(string.IsNullOrEmpty(ErrorText) ? "" : $"error:{ErrorText}")})";
    }
}
