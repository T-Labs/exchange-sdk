using System;

namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>
    /// A crypto deposit that AML flagged as risky. The funds physically stay on the adapter
    /// (hot wallet) address and are NOT credited until an admin approves or returns them.
    /// Stored in the Brokerage.CashRefill database; also used as the transport DTO for the admin UI.
    /// </summary>
    public class AmlPendingDeposit
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Where the hold came from. LiveDeposit = funds on adapter address, not credited.
        /// Backfill = historical deposit already credited; Approve only acknowledges it.
        /// </summary>
        public AmlScreeningSource Source { get; set; } = AmlScreeningSource.LiveDeposit;

        #region Original deposit data (enough to re-create the refill on approve)

        public string UserId { get; set; }
        public ClientType ClientType { get; set; } = ClientType.User;
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }

        /// <summary>Blockchain transaction hash of the incoming deposit.</summary>
        public string TxId { get; set; }

        /// <summary>Sender (source) blockchain address. Default return destination.</summary>
        public string FromAddress { get; set; }

        #endregion Original deposit data

        #region AML screening result

        public int RiskScore { get; set; }
        public AmlRiskLevel RiskLevel { get; set; } = AmlRiskLevel.Unknown;

        /// <summary>Provider risk labels, stored comma-separated.</summary>
        public string RiskLabels { get; set; }

        /// <summary>Raw provider response for the admin audit trail.</summary>
        public string ScreeningRaw { get; set; }

        public DateTimeOffset ScreenedAt { get; set; }

        /// <summary>When the deposit was received: the on-chain deposit time for backfill, or when it reached AML for live deposits.
        /// MinValue for rows created before this field existed.</summary>
        public DateTimeOffset ReceivedAt { get; set; }

        #endregion AML screening result

        #region Review state

        public AmlPendingDepositStatus Status { get; set; } = AmlPendingDepositStatus.Pending;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ResolvedAt { get; set; }

        /// <summary>Admin who approved/returned the deposit.</summary>
        public string ResolvedByUserId { get; set; }

        /// <summary>Percent withheld on return (e.g. 10 = keep 10%, send back 90%). Null until returned.</summary>
        public decimal? HoldPercent { get; set; }

        /// <summary>Blockchain tx hash of the return send, when returned.</summary>
        public string ReturnTxId { get; set; }

        public string Comment { get; set; }

        /// <summary>Link to the screening record that triggered this hold.</summary>
        public Guid? ScreeningRecordId { get; set; }

        #endregion Review state

        public override string ToString() =>
            $"{nameof(AmlPendingDeposit)}(Id:{Id}, {Status}, {Amount} {CurrencyCode} ({AdapterCode}), " +
            $"user:{UserId}, score:{RiskScore}, txId:{TxId})";
    }
}
