using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Depository
{
    public class CryptoDepositsFilterDto
    {
        /// <summary>Inclusive lower bound (required).</summary>
        public DateTimeOffset From { get; set; }

        /// <summary>Exclusive upper bound (required). Must be &gt; From.</summary>
        public DateTimeOffset To { get; set; }

        /// <summary>Null or empty = all currencies. Trim; drop blank entries before query.</summary>
        public List<string> CurrencyCodes { get; set; }

        /// <summary>Null or empty = all adapters. Trim; drop blank entries before query.</summary>
        public List<string> AdapterCodes { get; set; }
    }
}
