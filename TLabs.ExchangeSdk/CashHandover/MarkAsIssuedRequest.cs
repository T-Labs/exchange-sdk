using System;

namespace TLabs.ExchangeSdk.CashHandover;

public class MarkAsIssuedRequest
{
    public Guid RequestId { get; set; }
    public byte[] PayoutImage { get; set; }
}
