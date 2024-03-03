using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P;

public class Requisite
{
    [Key]
    public Guid Id { get; set; }

    public int PaymentSystemId { get; set; }

    public string PaymentMethodCurrencyCode { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public string CardNumber { get; set; }

    [Required]
    public string OwnerName { get; set; }
    public string BankBranch { get; set; }
    public string BankName { get; set; }

    public string Comment { get; set; }
    public bool IsDeleted { get; set; }
    public PaymentSystem PaymentSystem { get; set; }
}
