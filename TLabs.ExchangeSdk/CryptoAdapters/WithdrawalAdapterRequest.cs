using System;
using TLabs.ExchangeSdk.Withdrawals;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    /// <summary>Withdrawal request</summary>
    public class WithdrawalAdapterRequest
    {
        public WithdrawalType WithdrawalType { get; set; } = WithdrawalType.Crypto;

        public ClientType ClientType { get; set; }

        /// <summary>User that requested withdrawal</summary>
        public string UserId { get; set; }

        /// <summary>Withdrawal Amount</summary>
        public decimal Amount { get; set; }

        /// <summary>CurrencyCode</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Where to withdraw</summary>
        public string Address { get; set; }

        /// <summary>Public key of node's address, required only for Prizm (PZM)</summary>
        public string AddressPublicKey { get; set; }

        /// <summary>Additional Id set in blockchain tx comment, used in TON network</summary>
        public string Memo { get; set; }

        /// <summary>Transaction number in depository</summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Blockchain tx the coins must be taken from, "hash_vout" in UTXO networks. Used by AML deposit returns
        /// to send back the very coins that were held, instead of whatever the node would pick on its own.
        /// Account-based adapters use it to resolve the held deposit address.
        /// </summary>
        public string SourceTxId { get; set; }

        /// <summary>
        /// For AML deposit returns the network fee must be taken from a dedicated fee source, not from the main hot wallet.
        /// </summary>
        public bool UseDedicatedFeeWallet { get; set; }

        /// <summary>true if it's admin withdrawal to cold wallet</summary>
        public bool IsToColdWallet { get; set; }

        /// <summary>Only used with WithdrawalType.AdvCashBankCard</summary>
        public WithdrawalBankCardDto BankCard { get; set; }

        public override string ToString() => $"{nameof(WithdrawalAdapterRequest)}({(IsToColdWallet ? "ToColdWallet" : "")}" +
            $" {ClientType} {UserId}, {Amount} {CurrencyCode}, to {Address}, {WithdrawalType})";

        public void Trim()
        {
            UserId = UserId?.Trim();
            Address = Address?.Trim();
            AddressPublicKey = AddressPublicKey?.Trim();
        }
    }
}
