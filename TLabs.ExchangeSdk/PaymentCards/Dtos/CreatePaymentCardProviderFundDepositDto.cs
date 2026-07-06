namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class CreatePaymentCardProviderFundDepositDto
{
    public string AdminUserId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public string Comment { get; set; }

    public override string ToString() =>
        $"{nameof(CreatePaymentCardProviderFundDepositDto)}(admin:{AdminUserId}, amount:{Amount} {CurrencyCode})";
}
