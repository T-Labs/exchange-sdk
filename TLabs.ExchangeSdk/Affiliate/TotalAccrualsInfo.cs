using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class TotalAccrualsInfo
    {
        /// <summary>Referral userId</summary>
        public string FromUserId { get; set; }

        /// <summary>Readable referral identificator</summary>
        public string FromUsername { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public int Level { get; set; }

        public Dictionary<string, decimal> TotalAmountsByCurrency { get; set; }
    }
}
