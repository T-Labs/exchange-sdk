using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Commissions
{
    public class CommissionValue
    {
        public CommissionValue()
        {
        }

        public CommissionValue(decimal amount, string currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }
    }
}
