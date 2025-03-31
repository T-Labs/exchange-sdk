using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class TotalAccrualsInfo
    {
        /// <summary>Referral userId</summary>
        public string FromUserId { get; set; }

        /// <summary>Readable referral identificator</summary>
        public string FromUsername { get; set; }

        public int Level { get; set; }

        public Dictionary<string, decimal> TotalAmountsByCurrency { get; set; }
    }
}
