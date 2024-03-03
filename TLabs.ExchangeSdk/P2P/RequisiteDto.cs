using System.ComponentModel.DataAnnotations;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.P2P;

public class RequisiteDto
{
    public int PaymentSystemId { get; set; }

    public string PaymentMethodCurrencyCode { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public string CardNumber { get; set; }

    [Required]
    public string Name { get; set; }

    public string Comment { get; set; }
    public string BankBranch { get; set; }
    public string BankName { get; set; }

    public void Trim()
    {
        PaymentMethodCurrencyCode = PaymentMethodCurrencyCode?.Trim()?.NullIfEmpty();
        CardNumber = CardNumber?.Trim()?.NullIfEmpty();
        Name = Name?.Trim()?.NullIfEmpty();
        Comment = Comment?.Trim()?.NullIfEmpty();
        BankBranch = BankBranch?.Trim()?.NullIfEmpty();
        BankName = BankName?.Trim()?.NullIfEmpty();
    }
}
