namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class UpdatePaymentCardProductFeesDto
{
    public decimal? ApplyFee { get; set; }
    public decimal? RechargeFee { get; set; }
    public decimal? RefundFee { get; set; }

    public override string ToString() => $"{nameof(UpdatePaymentCardProductFeesDto)}(ApplyFee:{ApplyFee}, RechargeFee:{RechargeFee}, RefundFee:{RefundFee})";
}