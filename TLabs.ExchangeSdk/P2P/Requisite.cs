using System;

namespace TLabs.ExchangeSdk.P2P;

public class Requisite
{
    public Guid Id { get; set; }
    public int PaymentSystemId { get; set; }
    public string PaymentMethodCurrencyCode { get; set; }
    public string UserId { get; set; }
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public bool IsDeleted { get; set; }
}
