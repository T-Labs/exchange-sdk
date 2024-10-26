using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Commissions
{
    public class CommissionType
    {
        public CommissionType()
        {
        }

        private CommissionType(string code, string value, string valueKey)
        {
            Code = code;
            Value = value;
            ValueKey = valueKey;
        }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Key for localization
        /// </summary>
        [Required]
        public string ValueKey { get; set; }

        public static readonly CommissionType Refill = new CommissionType("1", "Пополнение", nameof(Refill));
        public static readonly CommissionType Withdrawal = new CommissionType("2", "Вывод", nameof(Withdrawal));
        public static readonly CommissionType DealBid = new CommissionType("3", "Сделка покупка", nameof(DealBid));
        public static readonly CommissionType DealAsk = new CommissionType("4", "Сделка продажа", nameof(DealAsk));

        /// <summary>When P2P merchant buys crypto</summary>
        public static readonly CommissionType P2pBuy = new CommissionType("50", "P2P покупка", nameof(P2pBuy));

        /// <summary>When P2P merchant sells crypto</summary>
        public static readonly CommissionType P2pSell = new CommissionType("60", "P2P продажа", nameof(P2pSell));

        public static List<string> TypesUsingCurrencyPair = new List<string> { P2pBuy.Code, P2pSell.Code };
    }
}
