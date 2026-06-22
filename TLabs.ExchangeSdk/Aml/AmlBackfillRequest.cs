using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>One historical deposit to re-screen by transaction hash.</summary>
    public class AmlBackfillItem
    {
        public string TxId { get; set; }
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }

        /// <summary>Optional context — recipient user of the original deposit.</summary>
        public string UserId { get; set; }

        /// <summary>Optional context — amount credited at the time.</summary>
        public decimal? Amount { get; set; }

        /// <summary>Original on-chain deposit time; stored as the screening record's ReceivedAt (MinValue if unknown).</summary>
        public DateTimeOffset DepositedAt { get; set; }
    }

    /// <summary>Batch of historical deposits to screen and persist into the AML log.</summary>
    public class AmlBackfillRequest
    {
        public List<AmlBackfillItem> Items { get; set; } = new();
    }

    /// <summary>Summary returned after a backfill batch.</summary>
    public class AmlBackfillResult
    {
        public int Total { get; set; }

        /// <summary>Successfully screened and persisted.</summary>
        public int Screened { get; set; }

        /// <summary>Skipped because the same TxId was already screened (idempotency).</summary>
        public int Skipped { get; set; }

        /// <summary>Of the screened, how many returned a risky verdict.</summary>
        public int Risky { get; set; }

        /// <summary>Provider call failed (network, rate-limit, etc.) — counted separately, not persisted.</summary>
        public int Failed { get; set; }
    }
}
