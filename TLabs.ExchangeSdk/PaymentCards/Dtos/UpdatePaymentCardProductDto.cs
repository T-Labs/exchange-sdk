namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class UpdatePaymentCardProductDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public decimal? ApplyFee { get; set; }
    public decimal? RechargeFee { get; set; }
    public decimal? RefundFee { get; set; }

    public bool? Enabled { get; set; }

    public override string ToString() =>
        $"{nameof(UpdatePaymentCardProductDto)}(Title:{Title}, Enabled:{Enabled})";
}