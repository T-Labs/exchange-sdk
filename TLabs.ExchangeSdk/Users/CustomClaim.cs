namespace TLabs.ExchangeSdk.Users
{
    /// <summary>
    /// needed because identityserver Claim objects do not deserialize
    /// </summary>
    public class CustomClaim
    {
        public CustomClaim(string type, string value, string userId)
        {
            Type = type;
            Value = value;
            UserId = userId;
        }

        public string Type { get; set; }
        public string Value { get; set; }
        public string UserId { get; set; }
    }
}
