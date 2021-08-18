using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Trading
{
    public class Quote
    {
        [Key]
        public Guid QuoteId { get; set; }

        public string CurrencyCode { get; set; }

        public decimal? BtcRate { get; set; }

        public decimal? UsdtRate { get; set; }

        public decimal? InternalTokenRate { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
