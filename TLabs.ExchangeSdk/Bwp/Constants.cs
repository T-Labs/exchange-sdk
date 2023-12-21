using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Bwp
{
    public static class Constants
    {
        public const string CurrencyFiat = "RUB";
        public const string CurrencyCrypto = "USDT";

        /// <summary>Taken from merchant after each USDT transfer from a Trader</summary>
        public const decimal MerchantFeePercent = 5;

        /// <summary>Given to trader after each USDT transfer to a Merchant</summary>
        public const decimal TraderProfitPercent = 2;

        public const string GarantexBaseUrl = "https://garantex.org/api/v2";
    }
}
