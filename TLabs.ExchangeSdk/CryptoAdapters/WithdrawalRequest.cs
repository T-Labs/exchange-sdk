using System;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    /// <summary>Withdrawal request</summary>
    public class WithdrawalRequest
    {
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

        /// <summary>Transaction number in depository</summary>
        public Guid TransactionId { get; set; }

        /// <summary>true if it's admin withdrawal to cold wallet</summary>
        public bool IsToColdWallet { get; set; }

        public override string ToString() => $"{nameof(WithdrawalRequest)}({(IsToColdWallet ? "ToColdWallet" : "")}" +
            $" {ClientType} {UserId}, {Amount} {CurrencyCode}, to {Address})";

        public void Trim()
        {
            UserId = UserId?.Trim();
            Address = Address?.Trim();
            AddressPublicKey = AddressPublicKey?.Trim();
        }
    }
}
