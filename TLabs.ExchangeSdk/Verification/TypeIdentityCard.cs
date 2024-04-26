namespace TLabs.ExchangeSdk.Verification
{
    /// <summary>
    /// Identity document verification type
    /// </summary>
    public class TypeIdentityCard
    {
        /// <summary>
        /// Number in data base
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in English
        /// </summary>
        public string Name_EN { get; set; }
    }
}
