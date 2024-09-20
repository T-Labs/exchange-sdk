using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Farming.Dtos
{
    public class UserCountsByRegion
    {
        public int TotalCount { get; set; }

        public Dictionary<Region, int> CountWithoutConnectedWallets { get; set; }
        public Dictionary<Region, int> CountWithConnectedWallets { get; set; }
    }
}
