using System.Collections.Generic;
using TLabs.ExchangeSdk.PaymentCards.Enums;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardAdminCardsQueryDto
{
    public int Skip { get; set; }

    public int Take { get; set; } = 50;

    public List<string> UserIds { get; set; }

    public bool Physical { get; set; }

    public PaymentCardStatus? Status { get; set; }

    public string Search { get; set; }
}
