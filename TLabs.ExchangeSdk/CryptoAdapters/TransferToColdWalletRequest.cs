namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class TransferToColdWalletRequest
    {
        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }

        public string ColdWalletAddress { get; set; }
    }
}
