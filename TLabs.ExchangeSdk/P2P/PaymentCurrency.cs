using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class PaymentCurrency
{
    [Key]
    public string CurrencyCode { get; set; }

    public bool IsActive { get; set; }
}
