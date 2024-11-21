using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies;

public class P2PExchangeCurrency
{
    [Required]
    public string CurrencyCode { get; set; }

    public int Ordering { get; set; }
}
