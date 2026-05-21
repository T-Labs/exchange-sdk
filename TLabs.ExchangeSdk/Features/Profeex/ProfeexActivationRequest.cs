namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexActivationRequest
{
    public string Address { get; set; }

    public ProfeexCurrency Currency { get; set; } = ProfeexCurrency.TRX;
}
