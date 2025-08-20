using System;

namespace TLabs.ExchangeSdk.CashExchanges;

public class Correction
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }
    public DateTimeOffset Date { get; set; }
    public decimal? UsdtValue { get; set; }
    public decimal? TrxValue { get; set; }
    public decimal? UsdValue { get; set; }
    public decimal? TryValue { get; set; }
    public decimal? EurValue { get; set; }
    public bool IsChanged { get; set; }
}
