using System;

namespace TLabs.ExchangeSdk.CashHandover;

public class CancelRequestDto
{
    public Guid RequestId { get; set; }
    public string Reason { get; set; }
}
