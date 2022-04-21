using System;
using System.Linq;

namespace TLabs.ExchangeSdk.Staking
{
    public class StakingFundProfitDto
    {
        public string ActionId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }

        public override string ToString() => $"{nameof(StakingFundProfitDto)}({Amount} {CurrencyCode}, ActionId:{ActionId})";
    }
}
