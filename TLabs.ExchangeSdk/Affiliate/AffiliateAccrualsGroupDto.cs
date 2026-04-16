using System;

namespace TLabs.ExchangeSdk.Affiliate;

public class AffiliateAccrualsGroupDto
{
    public DateTimeOffset Date { get; set; }
    public int ProfitType { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
}
