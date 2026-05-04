namespace TLabs.ExchangeSdk.Commissions
{
    public class CommissionDiscountUpsertDto
    {
        public string UserId { get; set; }

        public string CommissionTypeCode { get; set; }

        /// <summary>Discount fraction applied as payable commission *= (1 - Percentage); server clamps to [0, 0.5].</summary>
        public decimal Percentage { get; set; }
    }

    public class TradingCommissionDiscountUpsertDto
    {
        public string UserId { get; set; }

        /// <summary>Applied to both DealBid and DealAsk commission types.</summary>
        public decimal Percentage { get; set; }
    }
}
