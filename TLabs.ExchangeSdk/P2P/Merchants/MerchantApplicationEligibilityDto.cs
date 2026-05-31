namespace TLabs.ExchangeSdk.P2P.Merchants;

public class MerchantApplicationEligibilityDto
{
    public bool CanSubmit { get; set; }

    public bool HasSufficientBalance { get; set; }

    public bool MeetsVerificationRequirement { get; set; }

    public bool VerificationRequiredByPlatform { get; set; }

    public bool IsAlreadyMerchant { get; set; }

    public bool HasPendingApplication { get; set; }

    public decimal RequiredCollateralAmount { get; set; }

    public string CollateralCurrencyCode { get; set; }

    public decimal AvailableBalance { get; set; }
}
