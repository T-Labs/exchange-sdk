using System;

namespace TLabs.ExchangeSdk.CashHandover;

public class CashHandoverRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ClientName { get; set; }
    public decimal Amount { get; set; }
    public int DealNumber { get; set; }
    public string CurrencyCode { get; set; }
    public byte[] PassportPhoto { get; set; }
    public byte[] PaymentImage { get; set; }
    public byte[] PayoutImage { get; set; }
    public decimal? IssuedAmount { get; set; }
    public CashHandoverRequestStatus Status { get; set; }
    public string CancelReason { get; set; }
    public DateTimeOffset Created { get; set; }
}
