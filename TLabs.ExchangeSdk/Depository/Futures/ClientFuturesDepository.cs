using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Depository.Futures
{
    public class ClientFuturesDepository
    {
        private const string BaseUrl = "depository/futures-ledger";
        private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(10);

        public async Task<FuturesLedgerAccountSnapshot> EnsureAccount(
            FuturesLedgerEnsureAccountRequest request,
            CancellationToken cancellationToken = default)
        {
            return await $"{BaseUrl}/accounts".InternalApi()
                .WithTimeout(RequestTimeout)
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<FuturesLedgerAccountSnapshot>();
        }

        public async Task<FuturesLedgerAccountSnapshot> GetAccount(
            long futuresAccountId,
            string userId,
            string currencyCode,
            CancellationToken cancellationToken = default)
        {
            return await $"{BaseUrl}/accounts/{futuresAccountId}".InternalApi()
                .WithTimeout(RequestTimeout)
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .GetJsonAsync<FuturesLedgerAccountSnapshot>(cancellationToken: cancellationToken);
        }

        public async Task<FuturesLedgerOperationResult> ExecuteOperation(
            FuturesLedgerOperationRequest request,
            CancellationToken cancellationToken = default)
        {
            return await $"{BaseUrl}/operations".InternalApi()
                .WithTimeout(RequestTimeout)
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<FuturesLedgerOperationResult>();
        }
    }
}
