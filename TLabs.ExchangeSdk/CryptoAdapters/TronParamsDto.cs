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
        public bool UseFreezeForWithdrawals { get; set; }

        public int FreezeForTrc20WithdrawalsCount { get; set; }
        public decimal FreezeForTrc20WithdrawalsPercentage { get; set; }
    }
}
