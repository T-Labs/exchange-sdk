using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexOrderAcceptedDto
{
    public string Message { get; set; }

    public string TaskId { get; set; }

    public ProfeexOrderStatus Status { get; set; }

    public string Target { get; set; }

    public long Volume { get; set; }

    public string Days { get; set; }

    public ProfeexCurrency Currency { get; set; }

    public ProfeexResourceType ResourceType { get; set; }

    public Dictionary<string, string> Balances { get; set; }
}
