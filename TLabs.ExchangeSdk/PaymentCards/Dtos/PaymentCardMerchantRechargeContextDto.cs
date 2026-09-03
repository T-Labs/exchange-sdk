using System.Collections.Generic;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardMerchantRechargeContextDto
{
    public decimal MerchantBalance { get; set; }

    public decimal FundsBalance { get; set; }

    public string TokenSymbol { get; set; }

    public string CurrencyCode { get; set; }

    public List<PaymentCardMerchantRechargeNetworkDto> Networks { get; set; } = new();
}
