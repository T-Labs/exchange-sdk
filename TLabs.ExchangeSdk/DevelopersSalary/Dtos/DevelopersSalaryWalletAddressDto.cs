namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>Fund address of a network, created and kept by the adapter.</summary>
    public class DevelopersSalaryWalletAddressDto
    {
        public string AdapterCode { get; set; }

        public string Address { get; set; }

        /// <summary>Error text when the adapter did not return an address.</summary>
        public string ErrorText { get; set; }

        public override string ToString() =>
            $"{nameof(DevelopersSalaryWalletAddressDto)}({AdapterCode}: {Address}{ErrorText})";
    }
}
