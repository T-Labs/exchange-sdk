using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class ClientAffiliate
    {
        private readonly ILogger _logger;

        public ClientAffiliate(
            ILogger<ClientAffiliate> logger)
        {
            _logger = logger;
        }

        public async Task<List<Profit>> GetProfits(List<Guid> ids)
        {
            var result = await $"affiliate/profits".InternalApi()
                .SetQueryParam(nameof(ids), ids)
                .GetJsonAsync<List<Profit>>();
            return result;
        }
    }
}
