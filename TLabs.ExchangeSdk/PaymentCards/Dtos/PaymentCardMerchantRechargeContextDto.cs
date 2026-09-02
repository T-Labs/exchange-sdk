namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardMerchantRechargeContextDto
{
    public decimal MerchantBalance { get; set; }

    public string SourceUserId { get; set; }

    public decimal? SourceUserBalance { get; set; }

    public string Chain { get; set; }

    public string TokenSymbol { get; set; }

    public string CurrencyCode { get; set; }
}
