namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Lifecycle of a deposit that was put on hold by an AML check.</summary>
    public enum AmlPendingDepositStatus
    {
        /// <summary>Flagged by AML, waiting for an admin decision. Funds stay on the adapter address.</summary>
        Pending = 10,

        /// <summary>Admin accepted the deposit; it was processed as a normal refill.</summary>
        Approved = 20,

        /// <summary>Admin returned the funds to the sender (minus the withheld percent).</summary>
        Returned = 30,

        /// <summary>Return was requested but the blockchain send failed; needs a retry.</summary>
        ReturnFailed = 40,

        /// <summary>Approve is in progress: depository post + cold-wallet transfer.
        /// Intermediate state — prevents concurrent double-approve.</summary>
        Approving = 50,

        /// <summary>Return is in progress: on-chain send via withdrawals.
        /// Intermediate state — prevents concurrent double-send.</summary>
        Returning = 60,
    }
}
