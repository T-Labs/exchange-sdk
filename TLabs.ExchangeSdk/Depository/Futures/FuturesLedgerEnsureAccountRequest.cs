namespace TLabs.ExchangeSdk.Depository.Futures
{
    public class FuturesLedgerEnsureAccountRequest
    {
        public long FuturesAccountId { get; set; }
        public string UserId { get; set; }
        public string CurrencyCode { get; set; }
    }
}
