namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexPrecountRequest
{
    public long Volume { get; set; }

    /// <summary>One of ProfeexDuration constants: 1h, 1d, 3d, 7d, 14d.</summary>
    public string Days { get; set; }

    public ProfeexCurrency Currency { get; set; }
}
