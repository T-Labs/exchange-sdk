namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Admin request to return a flagged deposit to the sender, withholding a percent.</summary>
    public class AmlReturnRequest
    {
        /// <summary>Percent withheld on the adapter address (e.g. 10 = send back 90%, keep 10%).</summary>
        public decimal HoldPercent { get; set; }

        /// <summary>Optional override of the destination address. Defaults to the deposit's FromAddress.</summary>
        public string ReturnAddress { get; set; }

        public string Comment { get; set; }
    }
}
