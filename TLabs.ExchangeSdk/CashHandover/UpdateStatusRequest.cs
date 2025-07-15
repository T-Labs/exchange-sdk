using System;

namespace TLabs.ExchangeSdk.CashHandover;

public class UpdateStatusRequest
{
    public Guid Id { get; set; }
    public CashHandoverRequestStatus Status { get; set; }
}
