namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardProviderFundBalanceDto
{
    public decimal Balance { get; set; }
    public string CurrencyCode { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardProviderFundBalanceDto)}(balance:{Balance} {CurrencyCode})";
}
