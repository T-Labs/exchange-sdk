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

        public static Adapter AdapterBtc = new Adapter { Code = "btc", Name = "Bitcoin", MainCurrencyCode = "BTC", };
        public static Adapter AdapterDash = new Adapter { Code = "dash", Name = "Dash", MainCurrencyCode = "DASH", };
        public static Adapter AdapterDoge = new Adapter { Code = "doge", Name = "Dogecoin", MainCurrencyCode = "DOGE", };
        public static Adapter AdapterLtc = new Adapter { Code = "ltc", Name = "Litecoin", MainCurrencyCode = "LTC", };
        public static Adapter AdapterEth = new Adapter { Code = "eth", Name = "Ethereum", MainCurrencyCode = "ETH", };
        public static Adapter AdapterBsc = new Adapter { Code = "bsc", Name = "Binance Smart Chain", MainCurrencyCode = "BNB", };
        public static Adapter AdapterTrx = new Adapter { Code = "trx", Name = "Tron", MainCurrencyCode = "TRX", };
        public static Adapter AdapterDel = new Adapter { Code = "del", Name = "Decimal", MainCurrencyCode = "DEL", };
        public static Adapter AdapterPzm = new Adapter { Code = "pzm", Name = "Prizm", MainCurrencyCode = "PZM", };
        public static Adapter AdapterAdvcash = new Adapter { Code = "advcash", Name = "AdvCash", MainCurrencyCode = null, IsFiat = true, };

        public static List<Adapter> DefaultAdapters = new()
        {
            AdapterBtc, AdapterDash, AdapterDoge, AdapterLtc,
            AdapterEth, AdapterBsc, AdapterTrx, AdapterDel, AdapterPzm, AdapterAdvcash,
        };

        public override string ToString() =>
                    $"{nameof(Adapter)}({Code}, {Name}, MainCurrencyCode:{MainCurrencyCode})";
    }
}
