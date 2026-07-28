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

        /// <summary>
        /// Transaction failed in blockchain, withdrawal should be moved to Error status
        /// </summary>
        public bool IsFailed { get; set; }

        public string ErrorText { get; set; }

        public override string ToString() => $"{nameof(WithdrawalAdapterConfirmation)}(DepositoryTransactionId:{TransactionId}, IsToColdWallet:{IsToColdWallet}, " +
            $"NetworkCommission:{NetworkCommission} {NetworkCommissionCurrencyCode}, IsFailed:{IsFailed}, ErrorText:{ErrorText})";
    }
}
