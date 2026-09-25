namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    public class FundPayoutSettingsDto
    {
        public string FundCode { get; set; }

        public string CurrencyCode { get; set; }

        /// <summary>Comma-separated adapter codes, e.g. "trx,bsc".</summary>
        public string AdapterCodes { get; set; }

        public bool IsEnabled { get; set; }

        public override string ToString() =>
            $"{nameof(FundPayoutSettingsDto)}({FundCode}, {CurrencyCode} via {AdapterCodes}, enabled:{IsEnabled})";
    }
}
