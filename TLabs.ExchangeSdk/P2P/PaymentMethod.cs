using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class PaymentMethod
{
    public int PaymentSystemId { get; set; }
    public string CurrencyCode { get; set; }
}
