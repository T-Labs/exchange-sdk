using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Withdrawals
{
    public class ClientWithdrawals
    {
        const string baseUrl = "withdrawals/withdrawal";

        public async Task<List<Withdrawal>> GetWithdrawals(int? statusId = null, WithdrawalType? withdrawalType = null,
            string currencyCode = null, string userId = null)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(statusId), statusId)
                .SetQueryParam(nameof(withdrawalType), withdrawalType)
                .SetQueryParam(nameof(currencyCode), currencyCode.NullIfEmpty())
                .SetQueryParam(nameof(userId), userId.NullIfEmpty())
                .GetJsonAsync<List<Withdrawal>>();
            return result;
        }
    }
}
