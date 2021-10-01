using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.LiquidityImport
{
    public class ExchangeWithdrawalDto
    {
        public string Id { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal TransactionFee { get; set; }
        public string Coin { get; set; }
        public string Network { get; set; }
        public string Address { get; set; }
        public string TxId { get; set; }
        public DateTimeOffset ApplyTime { get; set; }

        public string StatusText => Status switch
        {
            0 => "Email Sent",
            1 => "Cancelled",
            2 => "Awaiting Approval",
            3 => "Rejected",
            4 => "Processing",
            5 => "Failure",
            6 => "Completed",
            _ => $"Unknown status '{Status}'"
        };
    }
}
