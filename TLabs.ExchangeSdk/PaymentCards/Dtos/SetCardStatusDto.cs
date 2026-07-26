using System.Collections.Generic;
using System.Linq;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class SetCardStatusDto
{
    public string Alter { get; set; } // ACTIVATE, LOCK, UNLOCK, CLOSE
    public string Reason { get; set; }
    public string ExternalId { get; set; }
    public string IdempotencyKey { get; set; }
    public string Pin { get; set; }

    public static readonly IReadOnlyList<string> ValidActions = new[]
    {
        "ACTIVATE", "LOCK", "UNLOCK", "CLOSE"
    };

    public bool IsValidAction() => Alter.HasValue() && ValidActions.Contains(Alter.ToUpperInvariant());
}