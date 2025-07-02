using System;

namespace TLabs.ExchangeSdk.CashHandover;

public class CashHandoverRequestDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ClientName { get; set; }
    public decimal Amount { get; set; }
    public byte[] PassportPhoto { get; set; }
    public byte[] PaymentImage { get; set; }
    public byte[] PayoutImage { get; set; }
    public CashHandoverRequestStatus Status { get; set; }
}
