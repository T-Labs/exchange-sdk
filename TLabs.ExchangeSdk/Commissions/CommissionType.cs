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

        public static readonly CommissionType Refill = new CommissionType("1", "Пополнение", "Refill");
        public static readonly CommissionType Withdrawal = new CommissionType("2", "Вывод", "Withdrawal");
        public static readonly CommissionType DealBid = new CommissionType("3", "Сделка покупка", "DealBid");
        public static readonly CommissionType DealAsk = new CommissionType("4", "Сделка продажа", "DealAsk");
    }
}
