using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings
{
    public enum CurrencyListingStatus
    {
        AwaitsPayment = 0,
        AwaitApproval = 10,
        Accepted = 20,
        Rejected = 30
    };

    public class CurrencyListing
    {
        [Key]
        public string CurrencyCode { get; set; }

        public const int TotalTokensAmount = 10_000_000;
        public int TokenDecimalPlaces { get; set; }

        public CurrencyListingStatus Status { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public decimal PaymentAmount { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string TokenName { get; set; }

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

        public int MarketPageDisplayOrder { get; set; }
    }
}
