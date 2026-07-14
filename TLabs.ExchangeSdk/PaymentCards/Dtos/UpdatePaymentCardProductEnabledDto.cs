namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class UpdatePaymentCardProductEnabledDto
{
    public bool Enabled { get; set; }

    public override string ToString() => $"{nameof(UpdatePaymentCardProductEnabledDto)}(Enabled:{Enabled})";
}
