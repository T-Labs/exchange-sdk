namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardMerchantRechargeResultDto
{
    public string OrderId { get; set; }

    public string Address { get; set; }

    public string QrBase64 { get; set; }

    public decimal Amount { get; set; }

    public string Chain { get; set; }

    public string TokenSymbol { get; set; }

    public bool WithdrawalSubmitted { get; set; }

    public string WithdrawalError { get; set; }
}
