using System;

namespace TLabs.ExchangeSdk.CashExchanges;

public class Correction
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public string Name { get; set; }
    public decimal? UsdtValue { get; set; }
    public decimal? TrxValue { get; set; }
    public decimal? UsdValue { get; set; }
    public decimal? TryValue { get; set; }
    public decimal? EurValue { get; set; }
    public bool IsChanged { get; set; }
}
