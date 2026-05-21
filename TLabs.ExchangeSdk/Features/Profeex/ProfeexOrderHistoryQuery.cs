using System;

namespace TLabs.ExchangeSdk.Features.Profeex;

public class ProfeexOrderHistoryQuery
{
    public int Page { get; set; } = 1;

    public int Size { get; set; } = 10;

    public DateTimeOffset? DateFrom { get; set; }

    public DateTimeOffset? DateTo { get; set; }

    /// <summary>Relative period (e.g. 7d, 24h, 1m). Overrides DateFrom/DateTo on the provider side.</summary>
    public string Last { get; set; }

    public ProfeexOrderStatus? Status { get; set; }

    public ProfeexResourceType? ResourceType { get; set; }

    /// <summary>Sort field. Prefix with '-' for descending. Default '-created_at'.</summary>
    public string Sort { get; set; } = "-created_at";
}
