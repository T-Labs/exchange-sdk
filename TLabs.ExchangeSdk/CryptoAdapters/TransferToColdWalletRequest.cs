namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class RequestTransferToColdWallet
    {
        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }

        public string ColdWalletAddress { get; set; }
    }
}
