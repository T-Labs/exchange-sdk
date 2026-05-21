namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexFeeCalculationDto
{
    public string ReceiverAddress { get; set; }

    public long EnergyRequired { get; set; }

    public decimal TrxBurned { get; set; }

    public bool IsNewAddress { get; set; }
}
