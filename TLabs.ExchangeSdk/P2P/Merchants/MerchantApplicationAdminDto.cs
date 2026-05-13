using System;

namespace TLabs.ExchangeSdk.P2P.Merchants;

public class MerchantApplicationAdminDto
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public string Status { get; set; }

    public decimal CollateralAmount { get; set; }

    public string CollateralCurrencyCode { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset? DateProcessed { get; set; }

    public string ProcessedByUserId { get; set; }

    public string Comment { get; set; }
}
