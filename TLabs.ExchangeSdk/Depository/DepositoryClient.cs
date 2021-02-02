using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Depository
{
    public class DepositoryClient
    {
        public DepositoryClient()
        {
        }

        public async Task<QueryResult> SendTxCommands(List<TxCommandDto> txCommands)
        {
            foreach (var command in txCommands)
            {
                command.TxTypeCode = command.TxTypeCode?.Trim().NullIfEmpty();
                command.CurrencyCode = command.CurrencyCode?.Trim().NullIfEmpty();
                command.UserId = command.UserId?.Trim().NullIfEmpty();
                command.ActionId = command.ActionId?.Trim().NullIfEmpty();
                command.TxId = command.TxId?.Trim().NullIfEmpty();
            }
            var result = await $"depository/transaction/commands".InternalApi()
                .PostJsonAsync(txCommands).GetQueryResult();
            return result;
        }

        public Task<QueryResult> SendTxCommand(TxCommandDto txCommand)
            => SendTxCommands(new List<TxCommandDto> { txCommand });

        public async Task<QueryResult<List<TransactionDto>>> GetTransactions(string userId = null, string currencyCode = null,
            DateTimeOffset? from = null, DateTimeOffset? to = null, List<string> transactionTypes = null, bool includeRollbacks = false)
        {
            var request = "depository/transaction/transactions".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .SetQueryParam(nameof(transactionTypes), transactionTypes)
                .SetQueryParam(nameof(includeRollbacks), includeRollbacks.ToString());
            var result = await request.GetJsonAsync<List<TransactionDto>>().GetQueryResult();
            return result;
        }

        public async Task<QueryResult<List<TransactionDto>>> GetTransactionsByActionIds(List<string> actionIds)
        {
            var result = await $"depository/transaction/actionid-transactions".InternalApi()
                .PostJsonAsync<List<TransactionDto>>(actionIds).GetQueryResult();
            return result;
        }

        public async Task<QueryResult<List<AccountBalance>>> GetAccountsBalances(string userId = null, string currencyCode = null,
            List<string> accountChartCodes = null, DateTimeOffset? toDate = null)
        {
            var request = $"depository/balances".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(accountChartCodes), accountChartCodes)
                .SetQueryParam(nameof(toDate), toDate?.ToString("o"));
            var result = await request.GetJsonAsync<List<AccountBalance>>().GetQueryResult();
            return result;
        }

        public async Task<QueryResult<UserBalancesDto>> GetUserBalances(string userId,
            IEnumerable<string> currencyCodes = null, DateTimeOffset? toDate = null)
        {
            var request = $"depository/user/{userId}/balances".InternalApi()
                .SetQueryParam(nameof(toDate), toDate?.ToString("o"))
                .SetQueryParam(nameof(currencyCodes), currencyCodes);
            var result = await request.GetJsonAsync<UserBalancesDto>().GetQueryResult();
            return result;
        }

        /// <summary>
        /// Get balance of Users account of the user
        /// </summary>
        public async Task<QueryResult<decimal>> GetUserAvailableBalance(string userId, string currencyCode)
        {
            var result = await $"depository/balance/{userId}/{currencyCode}".InternalApi()
                .GetJsonAsync<decimal>().GetQueryResult();
            return result;
        }
    }
}
