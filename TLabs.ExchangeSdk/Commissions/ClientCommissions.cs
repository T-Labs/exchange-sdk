using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Commissions
{
    public class ClientCommissions
    {
        public ClientCommissions()
        {
        }

        public virtual async Task<List<Commission>> GetCommissions(string type = null, List<string> currencies = null)
        {
            var request = $"commissions/commission".InternalApi();
            if (type.HasValue())
                request = request.SetQueryParam(nameof(type), type);
            if (currencies != null && currencies.Count > 0)
                request = request.SetQueryParam(nameof(currencies), currencies);

            return await request.GetJsonAsync<List<Commission>>();
        }

        public async Task<IFlurlResponse> UpdateCommission(Commission commission)
        {
            var result = await $"commissions/commission".InternalApi()
                .PostJsonAsync(commission);
            return result;
        }

        public async Task<CommissionValue> CalculateCommission(string commissionTypeCode, string currency, decimal amount,
            string userId, string adapterCode = null, string currencyPair = null, bool isAmountAfterCommission = false)
        {
            string url = $"commissions/commission/calculate/{commissionTypeCode}/{currency}/" +
                $"{amount.ToString(CultureInfo.InvariantCulture)}/{userId}";
            var commission = await url.InternalApi()
                .SetQueryParam(nameof(adapterCode), adapterCode)
                .SetQueryParam(nameof(currencyPair), currencyPair)
                .SetQueryParam(nameof(isAmountAfterCommission), isAmountAfterCommission)
                .GetJsonAsync<CommissionValue>();
            return commission;
        }

        /// <summary>Update currencies and create missing commission values</summary>
        public async Task<IFlurlResponse> NotifyCurrenciesChange()
        {
            var result = await $"commissions/currencies/reload".InternalApi()
                .PostAsync();
            return result;
        }

        public async Task<string> Healthcheck() =>
            await $"commissions/healthcheck".InternalApi().GetStringAsync();

        public virtual async Task UpsertCommissionUserDiscount(CommissionDiscountUpsertDto dto)
        {
            await $"commissions/commission-discounts".InternalApi()
                .PutJsonAsync(dto);
        }

        public virtual async Task UpsertTradingCommissionDiscounts(string userId, decimal percentage)
        {
            await $"commissions/commission-discounts/trading".InternalApi()
                .PutJsonAsync(new TradingCommissionDiscountUpsertDto
                {
                    UserId = userId,
                    Percentage = percentage,
                });
        }

        public virtual async Task<decimal> GetCommissionUserDiscountFraction(string userId, string commissionTypeCode)
        {
            return await $"commissions/commission-discounts/{userId}/{commissionTypeCode}".InternalApi()
                .GetJsonAsync<decimal>();
        }
    }
}
