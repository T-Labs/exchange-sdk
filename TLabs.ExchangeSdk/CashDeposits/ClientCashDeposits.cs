using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CashDeposits
{
    public class ClientCashDeposits
    {
        const string baseUrl = "withdrawals/cash-deposits";

        public async Task<List<CashDeposit>> GetList(bool? isDeposit, string currencyCode)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(isDeposit), isDeposit)
                .SetQueryParam(nameof(currencyCode), currencyCode.NullIfEmpty())
                .GetJsonAsync<List<CashDeposit>>();
            return result;
        }

        public async Task<CashDeposit> GetItem(Guid id)
        {
            var result = await $"{baseUrl}/{id}".InternalApi()
                .GetJsonAsync<CashDeposit>();
            return result;
        }

        public async Task<CashDeposit> Create(CashDeposit model)
        {
            var result = await $"{baseUrl}".InternalApi()
                .PostJsonAsync<CashDeposit>(model);
            return result;
        }

        public async Task<IFlurlResponse> ChangeStatus(Guid id, CashDepositStatus newStatus)
        {
            var result = await $"{baseUrl}/{id}/status".InternalApi()
                .SetQueryParam(nameof(newStatus), newStatus)
                .PostJsonAsync(null);
            return result;
        }
    }
}
