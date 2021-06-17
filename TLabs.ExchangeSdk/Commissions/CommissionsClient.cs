using Flurl.Http;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Commissions
{
    public class CommissionsClient
    {
        public CommissionsClient()
        {
        }

        public async Task<List<Commission>> GetCommissions()
        {
            var result = await $"commissions/commission".InternalApi()
                .GetJsonAsync<List<Commission>>();
            return result;
        }

        public async Task<CommissionValue> CalculateCommission(string commissionTypeCode, string currency, decimal amount,
            string userId, string currencyPair = "", bool isAmountAfterCommission = false)
        {
            string url = $"commissions/commission/calculate/{commissionTypeCode}/{currency}/" +
                $"{amount.ToString(CultureInfo.InvariantCulture)}/{userId}";
            var commission = await url.InternalApi()
                .SetQueryParam(nameof(currencyPair), currencyPair)
                .SetQueryParam(nameof(isAmountAfterCommission), isAmountAfterCommission)
                .GetJsonAsync<CommissionValue>();
            return commission;
        }
    }
}
