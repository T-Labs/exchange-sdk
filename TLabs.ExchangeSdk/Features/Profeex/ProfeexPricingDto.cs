namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexPricingDto
{
    public string Duration { get; set; }

    public long Volume { get; set; }

    public decimal Price { get; set; }

    public decimal Summa { get; set; }

    public ProfeexCurrency Currency { get; set; }
}
