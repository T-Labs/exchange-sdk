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

        public static Adapter AdapterBtc = new() { Code = "btc", Name = "Bitcoin", MainCurrencyCode = "BTC", };
        public static Adapter AdapterDash = new() { Code = "dash", Name = "Dash", MainCurrencyCode = "DASH", };
        public static Adapter AdapterDoge = new() { Code = "doge", Name = "Dogecoin", MainCurrencyCode = "DOGE", };
        public static Adapter AdapterLtc = new() { Code = "ltc", Name = "Litecoin", MainCurrencyCode = "LTC", };
        public static Adapter AdapterEth = new() { Code = "eth", Name = "Ethereum", MainCurrencyCode = "ETH", };
        public static Adapter AdapterBsc = new() { Code = "bsc", Name = "Binance Smart Chain", MainCurrencyCode = "BNB", };
        public static Adapter AdapterTrx = new() { Code = "trx", Name = "Tron", MainCurrencyCode = "TRX", };
        public static Adapter AdapterDel = new() { Code = "del", Name = "Decimal", MainCurrencyCode = "DEL", };
        public static Adapter AdapterPzm = new() { Code = "pzm", Name = "Prizm", MainCurrencyCode = "PZM", };
        public static Adapter AdapterUmi = new() { Code = "umi", Name = "Umi", MainCurrencyCode = "UMI", };
        public static Adapter AdapterAdvcash = new() { Code = "advcash", Name = "AdvCash", MainCurrencyCode = null, IsFiat = true, };

        public static List<Adapter> DefaultAdapters = new()
        {
            AdapterBtc, AdapterDash, AdapterDoge, AdapterLtc,
            AdapterEth, AdapterBsc, AdapterTrx, AdapterDel, AdapterPzm, AdapterUmi, AdapterAdvcash,
        };

        public override string ToString() =>
                    $"{nameof(Adapter)}({Code}, {Name}, MainCurrencyCode:{MainCurrencyCode})";
    }
}
