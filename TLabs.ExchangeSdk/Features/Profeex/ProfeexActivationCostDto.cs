namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexActivationCostDto
{
    public decimal CostTrx { get; set; }

    public string Description { get; set; }

    public ProfeexCurrency Currency { get; set; }
}
