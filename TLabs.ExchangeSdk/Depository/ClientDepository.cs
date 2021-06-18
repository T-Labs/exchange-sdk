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
    public class ClientDepository
    {
        public ClientDepository()
        {
        }

        public async Task<QueryResult> SendTxCommands(List<TxCommandDto> txCommands, bool checkBalances = true)
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
                .SetQueryParam(nameof(checkBalances), checkBalances)
                .PostJsonAsync(txCommands).GetQueryResult();
            return result;
        }

        public Task<QueryResult> SendTxCommand(TxCommandDto txCommand, bool checkBalances = true)
            => SendTxCommands(new List<TxCommandDto> { txCommand }, checkBalances);

        public async Task<List<TransactionDto>> GetTransactions(string userId = null, string currencyCode = null,
            DateTimeOffset? from = null, DateTimeOffset? to = null, List<string> transactionTypes = null, bool includeRollbacks = false)
        {
            var request = "depository/transaction/transactions".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .SetQueryParam(nameof(transactionTypes), transactionTypes)
                .SetQueryParam(nameof(includeRollbacks), includeRollbacks.ToString());
            var result = await request.GetJsonAsync<List<TransactionDto>>();
            return result;
        }

        public async Task<List<TransactionDto>> GetTransactionsByActionIds(List<string> actionIds)
        {
            var result = await $"depository/transaction/actionid-transactions".InternalApi()
                .PostJsonAsync<List<TransactionDto>>(actionIds);
            return result;
        }

        public async Task<List<AccountBalance>> GetAccountsBalances(string userId = null, string currencyCode = null,
            List<string> accountChartCodes = null, DateTimeOffset? toDate = null)
        {
            var request = $"depository/balances".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(accountChartCodes), accountChartCodes)
                .SetQueryParam(nameof(toDate), toDate?.ToString("o"));
            var result = await request.GetJsonAsync<List<AccountBalance>>();
            return result;
        }

        public async Task<UserBalancesDto> GetUserBalances(string userId,
            IEnumerable<string> currencyCodes = null, DateTimeOffset? toDate = null)
        {
            var request = $"depository/user/{userId}/balances".InternalApi()
                .SetQueryParam(nameof(toDate), toDate?.ToString("o"))
                .SetQueryParam(nameof(currencyCodes), currencyCodes);
            var result = await request.GetJsonAsync<UserBalancesDto>();
            return result;
        }

        /// <summary>Get balance of Users account of the user</summary>
        public async Task<decimal> GetUserAvailableBalance(string userId, string currencyCode)
        {
            var result = await $"depository/balance/{userId}/{currencyCode}".InternalApi()
                .GetJsonAsync<decimal>();
            return result;
        }
    }
}
