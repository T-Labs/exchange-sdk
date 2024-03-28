namespace TLabs.ExchangeSdk.Users
{
    /// <summary>
    /// only needed because identityserver Claim objects do not deserialize
    /// </summary>
    public class CustomClaim
    {
        public CustomClaim(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
