namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class ConfirmPaymentCard3DsDto
{
    public long SecurementId { get; set; }

    public string Action { get; set; }

    public override string ToString() =>
        $"{nameof(ConfirmPaymentCard3DsDto)}(securementId:{SecurementId}, action:{Action})";
}
