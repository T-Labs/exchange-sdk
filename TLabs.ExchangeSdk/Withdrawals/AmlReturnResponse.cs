namespace TLabs.ExchangeSdk.Withdrawals
{
    /// <summary>Result of an AML on-chain return send executed by the withdrawals service.</summary>
    public class AmlReturnResponse
    {
        /// <summary>Blockchain tx hash of the return, when the send succeeded.</summary>
        public string TxId { get; set; }

        /// <summary>Error text, when the send failed (insufficient balance on adapter, network error, etc.).</summary>
        public string Error { get; set; }

        public bool Succeeded => string.IsNullOrEmpty(Error);
    }
}
