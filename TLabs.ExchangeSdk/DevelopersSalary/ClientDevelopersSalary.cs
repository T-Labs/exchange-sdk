using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

using TLabs.ExchangeSdk.DevelopersSalary.Dtos;
using TLabs.ExchangeSdk.DevelopersSalary.Enums;
using TLabs.ExchangeSdk.DevelopersSalary.Models;

namespace TLabs.ExchangeSdk.DevelopersSalary
{
    /// <summary>Client for developers salary wallet endpoints exposed by stock-withdrawals.</summary>
    public class ClientDevelopersSalary
    {
        private const string baseUrl = "withdrawals/developers-salary";

        public async Task<DevelopersSalarySettings> GetSettings()
        {
            return await $"{baseUrl}/settings".InternalApi()
                .GetJsonAsync<DevelopersSalarySettings>();
        }

        public async Task<QueryResult> SaveSettings(DevelopersSalarySettings settings)
        {
            return await $"{baseUrl}/settings".InternalApi()
                .PostJsonAsync(settings)
                .GetQueryResult();
        }

        /// <summary>Per-currency wallet balances with accrued/paid out totals.</summary>
        public async Task<List<DevelopersSalarySummaryItem>> GetSummary()
        {
            return await $"{baseUrl}/summary".InternalApi()
                .GetJsonAsync<List<DevelopersSalarySummaryItem>>();
        }

        public async Task<PagedList<DevelopersSalaryAccrual>> GetAccruals(
            string currencyCode = null, DevelopersSalaryAccrualStatus? status = null,
            int page = 1, int pageSize = 25)
        {
            return await $"{baseUrl}/accruals".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(status), status)
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<DevelopersSalaryAccrual>>();
        }

        public async Task<List<Developer>> GetDevelopers(bool includeArchived = false)
        {
            return await $"{baseUrl}/developers".InternalApi()
                .SetQueryParam(nameof(includeArchived), includeArchived)
                .GetJsonAsync<List<Developer>>();
        }

        /// <summary>Create or update a developer (addresses are managed separately).</summary>
        public async Task<QueryResult> SaveDeveloper(Developer developer)
        {
            return await $"{baseUrl}/developers".InternalApi()
                .PostJsonAsync(developer)
                .GetQueryResult();
        }

        public async Task<QueryResult> SetDeveloperArchived(Guid developerId, bool isArchived)
        {
            return await $"{baseUrl}/developers/{developerId}/archive".InternalApi()
                .SetQueryParam(nameof(isArchived), isArchived)
                .PostAsync()
                .GetQueryResult();
        }

        public async Task<QueryResult> AddDeveloperAddress(Guid developerId, DeveloperAddress address)
        {
            return await $"{baseUrl}/developers/{developerId}/addresses".InternalApi()
                .PostJsonAsync(address)
                .GetQueryResult();
        }

        public async Task<QueryResult> DeleteDeveloperAddress(Guid addressId)
        {
            return await $"{baseUrl}/addresses/{addressId}".InternalApi()
                .DeleteAsync()
                .GetQueryResult();
        }

        /// <summary>Send funds from the wallet to a developer address on-chain.</summary>
        public async Task<QueryResult> CreatePayout(CreateDeveloperPayoutRequest request)
        {
            return await $"{baseUrl}/payouts".InternalApi()
                .PostJsonAsync(request)
                .GetQueryResult();
        }

        public async Task<PagedList<DeveloperPayout>> GetPayouts(
            Guid? developerId = null, int page = 1, int pageSize = 25)
        {
            return await $"{baseUrl}/payouts".InternalApi()
                .SetQueryParam(nameof(developerId), developerId)
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .GetJsonAsync<PagedList<DeveloperPayout>>();
        }
    }
}
