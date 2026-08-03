using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class UpdatePaymentCardPhysicalOrderDto
{
    public PaymentCardPhysicalOrderStatus? Status { get; set; }

    public string TrackingNumber { get; set; }

    public string RecipientName { get; set; }

    public string CountryCode { get; set; }

    public string Region { get; set; }

    public string City { get; set; }

    public string Postcode { get; set; }

    public string AddressLine { get; set; }

    public string AdminNotes { get; set; }
}
