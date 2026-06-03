namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Risk verdict of an AML screening, derived from the provider's risk score.</summary>
    public enum AmlRiskLevel
    {
        Unknown = 0,
        Low = 1,
        Moderate = 2,
        High = 3,
        Severe = 4,
    }
}
