using System;
using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardAdminDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public int BananatechUserId { get; set; }
    public string BananatechCardId { get; set; }
    public string ExternalId { get; set; }
    public int TemplateId { get; set; }
    public Guid? PaymentCardProductId { get; set; }
    public PaymentCardStatus Status { get; set; }
    public string Type { get; set; }
    public string PaymentSystem { get; set; }
    public string CurrencyCode { get; set; }
    public string MaskedPan { get; set; }
    public bool HasPrintedCardNumber { get; set; }
    public bool HasActivationPin { get; set; }
    public decimal DepositAmount { get; set; }
    public decimal? RechargeFee { get; set; }
    public decimal? RechargeMinLimit { get; set; }
    public decimal? RechargeMaxLimit { get; set; }
    public string RegisterEmail { get; set; }
    public string RegisterDialCode { get; set; }
    public string RegisterPhoneNumber { get; set; }
    public string TrackingNumber { get; set; }
    public bool CanActivate { get; set; }
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

    public override string ToString() =>
        $"{nameof(PaymentCardAdminDto)}(id:{Id}, userId:{UserId}, status:{Status}, btUser:{BananatechUserId}, btCard:{BananatechCardId})";
}
