using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.CashTransfers;

namespace TLabs.ExchangeSdk.CashTransfers
{
    public class ClientCashTransfers
    {
        const string baseUrl = "withdrawals/cash-transfers";

        public async Task<List<CashTransfer>> GetList(bool? isDeposit, string currencyCode)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(isDeposit), isDeposit)
                .SetQueryParam(nameof(currencyCode), currencyCode.NullIfEmpty())
                .GetJsonAsync<List<CashTransfer>>();
            return result;
        }

        public async Task<CashTransfer> GetItem(Guid id)
        {
            var result = await $"{baseUrl}/{id}".InternalApi()
                .GetJsonAsync<CashTransfer>();
            return result;
        }

        public async Task<CashTransfer> Create(CashTransfer model)
        {
            var result = await $"{baseUrl}".InternalApi()
                .PostJsonAsync<CashTransfer>(model);
            return result;
        }

        public async Task<IFlurlResponse> ChangeStatus(Guid id, CashTransferStatus newStatus)
        {
            var result = await $"{baseUrl}/{id}/status".InternalApi()
                .SetQueryParam(nameof(newStatus), newStatus)
                .PostJsonAsync(null);
            return result;
        }
    }
}
