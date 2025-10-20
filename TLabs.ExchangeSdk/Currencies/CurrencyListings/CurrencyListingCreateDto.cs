using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings;

public class CurrencyListingCreateDto
{
    [Required]
    public string CurrencyCode { get; set; }

    public long TotalTokensAmount { get; set; }
    public int TokenDecimalPlaces { get; set; }

    public string UserId { get; set; }

    [Required]
    public string TokenName { get; set; }

    /// <summary>
    /// Fair launch is a special type of listing where the token is sold through bonding curve
    /// and then deployed to DEX.
    /// </summary>
    public bool UseFairLaunch { get; set; }

    public string ProjectGoal { get; set; }
    public string InvestmentCondition { get; set; }
    public string InvestmentConditionHint { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }

    public string OfficialLink { get; set; }
    public string WhitePaperLink { get; set; }
    public string LogoImageId { get; set; }

    public string HeaderImageId { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Content { get; set; }
    public string ProjectImageId { get; set; }

    public string SocialLink1 { get; set; }
    public string SocialLink2 { get; set; }
    public string SocialLink3 { get; set; }
    public string SocialLink4 { get; set; }

    public string PartnerLogoUrl { get; set; }
    public string PartnerPageUrl { get; set; }

    public int MarketPageDisplayOrder { get; set; }

    public decimal? OverriddenSupply { get; set; }
}
