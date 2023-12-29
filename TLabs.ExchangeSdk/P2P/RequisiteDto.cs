using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class RequisiteDto
{
    public int PaymentSystemId { get; set; }
    [Required]
    public string PaymentMethodCurrencyCode { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string CardNumber { get; set; }
    [Required]
    public string Name { get; set; }
    public string Comment { get; set; }
}
