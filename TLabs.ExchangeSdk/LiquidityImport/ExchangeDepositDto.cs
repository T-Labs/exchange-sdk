using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.LiquidityImport
{
    /// <summary>https://binance-docs.github.io/apidocs/spot/en/#deposit-history-supporting-network-user_data </summary>
    public class ExchangeDepositDto
    {
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public string Coin { get; set; }
        public string Network { get; set; }
        public string Address { get; set; }
        public string TxId { get; set; }
        public long InsertTime { get; set; }
        public DateTimeOffset GetDate() => TimeHelper.LongTimestampToDate(InsertTime);

        public string StatusText => Status switch
        {
            0 => "Pending",
            1 => "Success",
            6 => "Credited but cannot withdraw",
            _ => $"Unknown status '{Status}'"
        };
    }
}
