using System.Collections.Generic;

namespace TLabs.ExchangeSdk.FundPayouts.Dtos
{
    public class PayoutFundDto
    {
        public string Code { get; set; }

        public string AccountChartCode { get; set; }

        public bool AllowOneTimeAddress { get; set; }

        public FundPayoutSettingsDto Settings { get; set; }

        /// <summary>Null when depository is unavailable.</summary>
        public List<FundBalanceDto> Balances { get; set; }

        /// <summary>On-chain balance of each network hot wallet for the settings currency: adapterCode -> balance.</summary>
        public Dictionary<string, decimal> HotWalletBalances { get; set; }
    }
}
