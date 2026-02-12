using System;

namespace TLabs.ExchangeSdk.Affiliate.StakingAffiliate
{
    public class StakingAffiliateAccrualDto
    {
        public Guid ProfitId { get; set; }
        public string UserId { get; set; }
        public string FromUserId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
