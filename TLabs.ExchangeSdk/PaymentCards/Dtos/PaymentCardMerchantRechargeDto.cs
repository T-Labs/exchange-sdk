namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardMerchantRechargeDto
{
    public decimal Amount { get; set; }

    public string Chain { get; set; }

    public string TokenSymbol { get; set; }
}
