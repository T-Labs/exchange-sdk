namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Risk verdict of an AML screening, derived from the provider's risk score.</summary>
    public enum AmlRiskLevel
    {
        Unknown = 10,
        Low = 20,
        Moderate = 30,
        High = 40,
        Severe = 50,
    }
}
