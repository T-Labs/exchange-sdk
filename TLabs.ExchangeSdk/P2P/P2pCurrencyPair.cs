namespace TLabs.ExchangeSdk.P2P
{
    public class P2pCurrencyPair
    {
        public string ExchangeCurrencyCode { get; set; }

        public string PaymentCurrencyCode { get; set; }

        public PaymentCurrency PaymentCurrency { get; set; }

        public bool IsActive { get; set; }

        public string Code => $"{ExchangeCurrencyCode}_{PaymentCurrencyCode}";
    }
}
