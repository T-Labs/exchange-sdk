namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class DepositDto
    {
        public string UserId { get; set; }
        public ClientType ClientType { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string TxId { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
    }
}
