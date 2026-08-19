using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class ShippingInfo
{
    public string TrackingNumber { get; set; }
    public string RecipientName { get; set; }
    public string CountryCode { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string AddressLine { get; set; }
    public DateTimeOffset? DateShipped { get; set; }
}
