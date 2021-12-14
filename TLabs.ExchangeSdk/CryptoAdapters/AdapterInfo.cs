namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class AdapterInfo
    {
        public string MainCurrencyCode { get; set; }
        public string GlobalAddress { get; set; }
        public long? LastBlockAdapter { get; set; }
        public long? LastBlockNode { get; set; }
        public long? LastBlockPublicNode { get; set; }
        public int PendingDeposits { get; set; }
        public int PendingConsolidations { get; set; }
        public int PendingWithdrawals { get; set; }
    }
}
