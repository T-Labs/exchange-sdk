namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Where an AML screening came from.</summary>
    public enum AmlScreeningSource
    {
        /// <summary>Screened in the live refill flow, before crediting the user.</summary>
        LiveDeposit = 0,

        /// <summary>Screened retrospectively (historical deposit) via the backfill job.</summary>
        Backfill = 1,

        /// <summary>Triggered manually by an admin (ad-hoc check of a tx/address).</summary>
        Manual = 2,
    }
}
