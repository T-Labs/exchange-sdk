namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class WithdrawalConfirmationDto
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

        public override string ToString() => $"{nameof(WithdrawalConfirmationDto)}(DepositoryTransactionId:{TransactionId}, IsToColdWallet:{IsToColdWallet}, " +
            $"NetworkCommission:{NetworkCommission} {NetworkCommissionCurrencyCode})";
    }
}
