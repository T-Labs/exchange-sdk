using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.BinanceHandling
{
    public class BinanceHandlingPayment
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>null if not paid yet</summary>
        public DateTimeOffset? DatePaid { get; set; }

        /// <summary>Payement for dates range From</summary>
        public DateTimeOffset DateFrom { get; set; }
        /// <summary>Payement for dates range To</summary>
        public DateTimeOffset DateTo { get; set; }

        public Guid BinanceHandlingAccountId { get; set; }
        public BinanceHandlingAccount BinanceHandlingAccount { get; set; }

        /// <summary>Profit amount for which this payment was created, in currency of a bot</summary>
        public decimal ProfitAmount { get; set; }
        public string ProfitCurrency { get; set; }

        public decimal PaymentAmount { get; set; }
        public string PaymentCurrency { get; set; }

        /// <summary>from ProfitCurrency to PaymentCurrency</summary>
        public decimal CurrencyConversionRate { get; set; }

        public override string ToString() => $"BinanceHandlingPayment({Id}, {DateFrom:yyy-MM-dd} - {DateTo:yyy-MM-dd}, " +
            $"{PaymentAmount} {PaymentCurrency}, for profit of {ProfitAmount} {ProfitCurrency}, AccId: {BinanceHandlingAccountId}, " +
            $"Created: {DateCreated:o}, Paid:{DatePaid:o})";
    }
}
