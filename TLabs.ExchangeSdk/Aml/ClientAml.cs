using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Client for AML-pending-deposits endpoints exposed by stock-withdrawals.</summary>
    public class ClientAml
    {
        private const string baseUrl = "withdrawals/aml/deposits";

        /// <summary>Pending (and optionally resolved) deposits flagged by AML.</summary>
        public async Task<List<AmlPendingDeposit>> GetPendingDeposits(AmlPendingDepositStatus? status = null)
        {
            var result = await $"{baseUrl}/pending".InternalApi()
                .SetQueryParam(nameof(status), status)
                .GetJsonAsync<List<AmlPendingDeposit>>();
            return result;
        }

        public async Task<AmlPendingDeposit> GetPendingDeposit(Guid id)
        {
            var result = await $"{baseUrl}/pending/{id}".InternalApi()
                .GetJsonAsync<AmlPendingDeposit>();
            return result;
        }

        /// <summary>TxIds of deposits not yet AML-confirmed (anything not Approved) for an adapter — their address must not be consolidated.</summary>
        public async Task<List<string>> GetUnconfirmedTxIds(string adapterCode)
        {
            return await $"{baseUrl}/unconfirmed-txids".InternalApi()
                .SetQueryParam(nameof(adapterCode), adapterCode)
                .GetJsonAsync<List<string>>();
        }

        /// <summary>Accept the deposit and process it as a normal refill.</summary>
        public async Task<QueryResult> Approve(Guid id, string adminUserId)
        {
            return await $"{baseUrl}/pending/{id}/approve".InternalApi()
                .SetQueryParam(nameof(adminUserId), adminUserId)
                .PostAsync()
                .GetQueryResult();
        }

        /// <summary>Return the deposit to the sender, withholding <see cref="AmlReturnRequest.HoldPercent"/>.</summary>
        public async Task<QueryResult> Return(Guid id, string adminUserId, AmlReturnRequest request)
        {
            return await $"{baseUrl}/pending/{id}/return".InternalApi()
                .SetQueryParam(nameof(adminUserId), adminUserId)
                .PostJsonAsync(request)
                .GetQueryResult();
        }

        /// <summary>Append-only log of every AML screening (live deposits + backfill + manual), paged.</summary>
        public async Task<PagedList<AmlScreeningRecord>> GetScreeningRecords(
            DateTimeOffset? from = null, DateTimeOffset? to = null,
            AmlRiskLevel? minRiskLevel = null, AmlScreeningSource? source = null,
            int page = 1, int pageSize = 100)
        {
            var result = await $"{baseUrl}/records".InternalApi()
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .SetQueryParam(nameof(minRiskLevel), minRiskLevel)
                .SetQueryParam(nameof(source), source)
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<AmlScreeningRecord>>();
            return result;
        }

        /// <summary>Re-screen a batch of historical txs by hash. Idempotent: a tx already in the log is skipped.</summary>
        public async Task<AmlBackfillResult> Backfill(AmlBackfillRequest request)
        {
            var result = await $"{baseUrl}/backfill".InternalApi()
                .PostJsonAsync(request)
                .ReceiveJson<AmlBackfillResult>();
            return result;
        }

        /// <summary>Pull historical crypto-adapter deposits from depository in the date range and back-fill them.</summary>
        public async Task<AmlBackfillResult> BackfillFromDepository(DateTimeOffset? from = null, DateTimeOffset? to = null)
        {
            var result = await $"{baseUrl}/backfill-from-depository".InternalApi()
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .PostAsync()
                .ReceiveJson<AmlBackfillResult>();
            return result;
        }
    }
}
