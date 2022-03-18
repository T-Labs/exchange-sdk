using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Currencies
{
    public class Adapter
    {
        [Key]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string MainCurrencyCode { get; set; }
        public bool IsFiat { get; set; }

        public List<CurrencyAdapter> CurrencyAdapters { get; set; }

        public static List<Adapter> DefaultAdapters = new()
        {
            new Adapter { Code = "btc", Name = "Bitcoin", MainCurrencyCode = "BTC", },
            new Adapter { Code = "dash", Name = "Dash", MainCurrencyCode = "DASH", },
            new Adapter { Code = "doge", Name = "Dogecoin", MainCurrencyCode = "DOGE", },
            new Adapter { Code = "ltc", Name = "Litecoin", MainCurrencyCode = "LTC", },
            new Adapter { Code = "eth", Name = "Ethereum", MainCurrencyCode = "ETH", },
            new Adapter { Code = "bsc", Name = "Binance Smart Chain", MainCurrencyCode = "BNB", },
            new Adapter { Code = "trx", Name = "Tron", MainCurrencyCode = "TRX", },
            new Adapter { Code = "del", Name = "Decimal", MainCurrencyCode = "DEL", },
            new Adapter { Code = "pzm", Name = "Prizm", MainCurrencyCode = "PZM", },
            new Adapter { Code = "advcash", Name = "AdvCash", MainCurrencyCode = null, IsFiat = true, },
        };

        public override string ToString() =>
            $"{nameof(Adapter)}({Code}, {Name}, MainCurrencyCode:{MainCurrencyCode})";
    }
}
