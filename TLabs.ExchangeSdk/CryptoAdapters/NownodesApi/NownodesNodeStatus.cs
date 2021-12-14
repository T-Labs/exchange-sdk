using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.CryptoAdapters.NownodesApi
{
    public class NownodesNodeStatus
    {
        public NownodesNodeStatusBlockbook Blockbook { get; set; }
        public NownodesNodeStatusBackend Backend { get; set; }
    }

    public class NownodesNodeStatusBlockbook
    {
        public string Coin { get; set; }
        public string Version { get; set; }
        public long BestHeight { get; set; }
        public DateTimeOffset LastBlockTime { get; set; }
        public int Decimals { get; set; }
    }

    public class NownodesNodeStatusBackend
    {
        public string Chain { get; set; }
        public long Blocks { get; set; }
        public string BestBlockHash { get; set; }
        public string Version { get; set; }
    }
}
