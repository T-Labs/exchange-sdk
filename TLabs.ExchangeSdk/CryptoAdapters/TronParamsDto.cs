namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class TronParamsDto
    {
        // information
        public string GlobalAddress { get; set; }

        public decimal GlobalBalanceAvailable { get; set; }
        public decimal GlobalBalanceFrozenForWithdrawals { get; set; }
        public decimal GlobalBalanceFrozenForConsolidation { get; set; }
        public decimal FrozenTrxPer1Tx { get; set; }

        // configurable parameters
        public bool ParameterUseFreezeForConsolidation { get; set; }
        public bool ParameterUseFreezeForWithdrawals { get; set; }

        public int ParameterFreezeForTrc20TransactionsCount { get; set; }
        public decimal ParameterFreezeForTrc20TransactionsPercentage { get; set; }

        public int ParameterTrc20TxMaxEnergy { get; set; }
        public int ParameterEnergyPer1TrxBurn { get; set; }
    }
}
