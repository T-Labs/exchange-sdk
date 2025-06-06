using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.ExternalPayments
{
    public class ClientExternalPayments
    {
        private readonly ILogger _logger;

        private const string BaseUrl = "brokerage/external-payments";

        public ClientExternalPayments(
            ILogger<ClientExternalPayments> logger)
        {
            _logger = logger;
        }

        public async Task<List<ExternalPayment>> GetPayments(string userId = null)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<List<ExternalPayment>>();
            return result;
        }

        public async Task<ExternalPayment> AddPayment(ExternalPayment model)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .PutJsonAsync<ExternalPayment>(model);
            return result;
        }

        public async Task<List<ExternalPaymentFile>> GetPaymentFiles(string userId = null)
        {
            var result = await $"{BaseUrl}/files".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<List<ExternalPaymentFile>>();
            return result;
        }

        public async Task<ExternalPaymentFile> GetPaymentFile(Guid id)
        {
            var result = await $"{BaseUrl}/files/{id}".InternalApi()
                .GetJsonAsync<ExternalPaymentFile>();
            return result;
        }

        public async Task<ExternalPaymentFile> AddPaymentFile(ExternalPaymentFile model)
        {
            var result = await $"{BaseUrl}/files".InternalApi()
                .PutJsonAsync<ExternalPaymentFile>(model);
            return result;
        }
    }
}
