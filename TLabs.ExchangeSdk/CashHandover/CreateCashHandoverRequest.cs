using System;

namespace TLabs.ExchangeSdk.CashHandover;

public class CreateCashHandoverRequest
{
    public string Name { get; set; }
    public byte[] PassportPhoto { get; set; }
    public Guid ClientId { get; set; }
    public decimal Amount { get; set; }
    public byte[] PaymentImage { get; set; }
    public string DealNumber { get; set; }
}
