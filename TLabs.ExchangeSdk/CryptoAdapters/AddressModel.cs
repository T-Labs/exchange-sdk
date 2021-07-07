using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.CryptoAdapters
{
    public class AddressModel
    {
        /// <summary>Address Hash</summary>
        public string Address { get; set; }

        /// <summary>Public key of node's address, required only for Prizm (PZM)</summary>
        public string AddressPublicKey { get; set; }
    }
}
