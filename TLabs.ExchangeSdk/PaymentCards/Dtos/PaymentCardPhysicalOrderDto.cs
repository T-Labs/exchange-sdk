using System;
using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardPhysicalOrderDto
{
    public Guid Id { get; set; }

    public Guid UserPaymentCardId { get; set; }

    public string UserId { get; set; }

    public int TemplateId { get; set; }

    public Guid? PaymentCardProductId { get; set; }

    public PaymentCardPhysicalOrderStatus Status { get; set; }

    public PaymentCardStatus? CardStatus { get; set; }

    public string MaskedPan { get; set; }

    public bool HasPrintedCardNumber { get; set; }

    public bool HasActivationPin { get; set; }

    public string RegisterEmail { get; set; }

    public string RegisterDialCode { get; set; }

    public string RegisterPhoneNumber { get; set; }

    public string TrackingNumber { get; set; }

    public string RecipientName { get; set; }

    public string CountryCode { get; set; }

    public string Region { get; set; }

    public string City { get; set; }

    public string Postcode { get; set; }

    public string AddressLine { get; set; }

    public string AdminNotes { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateUpdated { get; set; }

    public DateTimeOffset? DateShipped { get; set; }
}
