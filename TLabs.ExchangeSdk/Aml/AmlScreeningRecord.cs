using System;

namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>
    /// Append-only log of every AML screening attempt (live deposits, backfill of historical txs, manual checks).
    /// Stored in the Brokerage.CashRefill database.
    /// </summary>
    public class AmlScreeningRecord
    {
        public Guid Id { get; set; }

        public DateTimeOffset ScreenedAt { get; set; }

        /// <summary>When the deposit was received: the on-chain deposit time for backfill, or when it reached AML for live deposits.
        /// MinValue for rows created before this field existed.</summary>
        public DateTimeOffset ReceivedAt { get; set; }

        public AmlScreeningSource Source { get; set; }

        #region Subject of the screening

        /// <summary>MistTrack coin code actually sent to the provider (e.g. BTC, USDT-TRC20).</summary>
        public string MistTrackCoinCode { get; set; }

        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }

        /// <summary>Blockchain address screened. Null when screening was by txid only.</summary>
        public string Address { get; set; }

        /// <summary>Blockchain transaction hash. Null when screening was by address only.</summary>
        public string TxId { get; set; }

        #endregion Subject of the screening

        #region Deposit context (optional, populated for live deposits / known historical txs)

        public string UserId { get; set; }
        public decimal? Amount { get; set; }

        #endregion Deposit context

        #region Result

        /// <summary>Risk score 3..100 (0 when inconclusive).</summary>
        public int RiskScore { get; set; }

        public AmlRiskLevel RiskLevel { get; set; } = AmlRiskLevel.Unknown;

        /// <summary>Risk labels, stored comma-separated.</summary>
        public string RiskLabels { get; set; }

        /// <summary>Raw provider JSON response (for the audit trail / admin drill-down).</summary>
        public string RawResponse { get; set; }

        /// <summary>True if the screening could not be performed (no key, network error, unsupported coin).</summary>
        public bool IsInconclusive { get; set; }

        #endregion Result

        /// <summary>When the screening led to holding the deposit, link to the pending workflow item.</summary>
        public Guid? PendingDepositId { get; set; }

        public override string ToString() =>
            $"{nameof(AmlScreeningRecord)}({Source}, {MistTrackCoinCode}, score:{RiskScore}, level:{RiskLevel}, " +
            $"tx:{TxId}, addr:{Address})";
    }
}
