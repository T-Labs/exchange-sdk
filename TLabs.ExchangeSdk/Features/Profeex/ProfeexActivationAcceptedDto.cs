using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexActivationAcceptedDto
{
    public string Message { get; set; }

    public string TaskId { get; set; }

    public ProfeexOrderStatus Status { get; set; }

    public string Target { get; set; }

    public Dictionary<string, string> Balances { get; set; }
}
