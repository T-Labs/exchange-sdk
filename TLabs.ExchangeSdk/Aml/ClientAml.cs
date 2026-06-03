using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Client for AML-pending-deposits endpoints exposed by Brokerage.CashRefill.</summary>
    public class ClientAml
    {
        private const string baseUrl = "cashrefill/aml";

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

        /// <summary>Append-only log of every AML screening (live deposits + backfill + manual).</summary>
        public async Task<List<AmlScreeningRecord>> GetScreeningRecords(
            DateTimeOffset? from = null, DateTimeOffset? to = null,
            AmlRiskLevel? minRiskLevel = null, AmlScreeningSource? source = null,
            int take = 500)
        {
            var result = await $"{baseUrl}/records".InternalApi()
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .SetQueryParam(nameof(minRiskLevel), minRiskLevel)
                .SetQueryParam(nameof(source), source)
                .SetQueryParam(nameof(take), take)
                .GetJsonAsync<List<AmlScreeningRecord>>();
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
