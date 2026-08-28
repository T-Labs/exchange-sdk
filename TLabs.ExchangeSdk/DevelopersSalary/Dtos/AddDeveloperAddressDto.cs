namespace TLabs.ExchangeSdk.DevelopersSalary.Dtos
{
    /// <summary>Add an external crypto address to a developer (developerId is passed in the route).</summary>
    public class AddDeveloperAddressDto
    {
        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        public string Address { get; set; }

        public string Memo { get; set; }

        public override string ToString() =>
            $"{nameof(AddDeveloperAddressDto)}({CurrencyCode} ({AdapterCode}), {Address})";
    }
}
