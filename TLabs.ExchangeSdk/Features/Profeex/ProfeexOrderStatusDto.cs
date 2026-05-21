using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexOrderStatusDto
{
    public string TaskId { get; set; }

    public ProfeexOrderStatus Status { get; set; }

    /// <summary>Provider-specific payload (target_address, volume, txid, error_message, ...).</summary>
    public Dictionary<string, object> Details { get; set; }

    public ProfeexErrorCode? ErrorCode { get; set; }
}
