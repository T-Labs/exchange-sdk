using System.Collections.Generic;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardAdminStatsQueryDto
{
    public List<string> UserIds { get; set; }

    public string Search { get; set; }
}
