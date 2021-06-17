using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Commissions
{
    public class CommissionsInfo
    {
        public List<Commission> Commissions { get; set; } = new List<Commission>();

        /// <summary>User has flag to not pay any trade commissions</summary>
        public bool UserNoTradeCommissions { get; set; }
    }
}
