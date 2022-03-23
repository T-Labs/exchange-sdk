namespace TLabs.ExchangeSdk.CryptoAdapters
{
    /// <summary>
    /// Transaction info for saving in Depository
    /// </summary>
    public class NewNodeTransactionDto
    {
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }
        public decimal Amount { get; set; }
        public string TxId { get; set; }
    }
}
