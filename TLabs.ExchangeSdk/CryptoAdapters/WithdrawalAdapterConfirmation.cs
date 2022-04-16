using TLabs.ExchangeSdk.Withdrawals;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class WithdrawalAdapterConfirmation
    {
        /// <summary>
        /// Depository WithdrawalBlock Transaction Id
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Optional. Blockchain TxId may change after withdrawal creation if transaction was resent
        /// </summary>
        public string BlockchainTxId { get; set; } = null;

        public bool IsToColdWallet { get; set; }

        public decimal NetworkCommission { get; set; }

        public string NetworkCommissionCurrencyCode { get; set; }

        public WithdrawalStatus Status { get; set; }

        public override string ToString() => $"{nameof(WithdrawalAdapterConfirmation)}(DepositoryTransactionId:{TransactionId}, IsToColdWallet:{IsToColdWallet}, " +
            $"NetworkCommission:{NetworkCommission} {NetworkCommissionCurrencyCode})";
    }
}
