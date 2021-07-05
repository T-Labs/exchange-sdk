namespace TLabs.ExchangeSdk.Exchanges
{
    public class ExchangePriceRequest
    {
        public string CurrencyPairCode { get; set; }
        public bool IsBid { get; set; }
        public string UserId { get; set; }
    }
}
