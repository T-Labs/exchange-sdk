using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Affiliate
{
    public enum ProfitType
    {
        TariffPurchase = 0,
        DealCommission = 1,
        WithdrawalCommission = 2,
        CardPurchase = 3,
        CurrencyListing = 40,
        ApiTradeProfitPayment = 50,
    }
}
