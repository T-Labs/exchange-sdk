using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Trading
{
    public class DeleteFakeOrdersRequest
    {
        public string CurrencyPairCode { get; set; }

        public List<Guid> OrderIds { get; set; }
    }
}
