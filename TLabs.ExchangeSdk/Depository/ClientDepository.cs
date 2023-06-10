using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Currencies;

namespace TLabs.ExchangeSdk.Depository
{
    public class ClientDepository
    {
        public ClientDepository()
        {
        }

        public async Task<QueryResult> SendTxCommands(List<TxCommandDto> txCommands, bool checkBalances = true,
            bool use2StepTransfer = false)
        {
            foreach (var command in txCommands)
            {
                command.TxTypeCode = command.TxTypeCode?.Trim().NullIfEmpty();
                command.CurrencyCode = command.CurrencyCode?.Trim().NullIfEmpty();
                command.UserId = command.UserId?.Trim().NullIfEmpty();
                command.FromUserId = command.FromUserId?.Trim().NullIfEmpty();
                command.ToUserId = command.ToUserId?.Trim().NullIfEmpty();
                command.ActionId = command.ActionId?.Trim().NullIfEmpty();
                command.TxId = command.TxId?.Trim().NullIfEmpty();
            }
            var result = await $"depository/transaction/commands".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(checkBalances), checkBalances)
                .SetQueryParam(nameof(use2StepTransfer), use2StepTransfer)
                .PostJsonAsync(txCommands).GetQueryResult();
            return result;
        }

        public Task<QueryResult> SendTxCommand(TxCommandDto txCommand, bool checkBalances = true)
            => SendTxCommands(new List<TxCommandDto> { txCommand }, checkBalances);

        public async Task<PagedList<TransactionDto>> GetTransactions(string userId = null, string currencyCode = null,
            DateTimeOffset? from = null, DateTimeOffset? to = null,
            List<string> transactionTypes = null, int page = 1, int pageSize = 50000,
            bool includeRollbacks = false)
        {
            var request = "depository/transaction".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(currencyCode), currencyCode)
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .SetQueryParam(nameof(transactionTypes), transactionTypes)
                .SetQueryParam(nameof(page), page)
                .SetQueryParam(nameof(pageSize), pageSize)
                .SetQueryParam(nameof(includeRollbacks), includeRollbacks.ToString());
            var result = await request.GetJsonAsync<PagedList<TransactionDto>>();
            return result;
        }

        public async Task<List<TransactionDto>> GetTransactionsByActionIds(List<string> actionIds)
        {
            var result = await $"depository/transaction/actionid-transactions".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .PostJsonAsync<List<TransactionDto>>(actionIds);
            return result;
        }

        public async Task<List<AccountBalance>> GetAccountsBalances(string userId = null, string currencyCode = null,
            List<string> accountChartCodes = null, DateTimeOffset? toDate = null)
        {
            var request = $"depository/balances".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
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
                .WithTimeout(TimeSpan.FromMinutes(10))
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

        public async Task<List<TurnoversDto>> GetTurnoversDtos(string userId = null, DateTimeOffset? toDate = null)
        {
            var result = await $"depository/turnovers".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(toDate), toDate?.ToString("o"))
                .GetJsonAsync<List<TurnoversDto>>();
            return result;
        }

        public async Task<string> OrderBlockOrUnblock(DepositoryReservationType type, string actionId,
            ClientType clientType, string userId, decimal amount, string currencyCode)
        {
            var dto = new DepositoryReservationDto
            {
                ReservationType = type,
                ActionId = actionId,
                ClientType = clientType,
                UserId = userId,
                Amount = amount,
                CurrencyCode = currencyCode
            };
            var responseMessage = await $"depository/deal/reserve".InternalApi()
                .PostJsonAsync<string>(dto);
            return responseMessage;
        }

        public async Task<IFlurlResponse> NullifyUserBalances(string userId)
        {
            if (userId.NotHasValue())
                throw new ArgumentNullException(nameof(userId));
            var result = await $"depository/nullification".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(userId), userId)
                .PostJsonAsync(null);
            return result;
        }

        #region Currencies

        public async Task<Currency> CreateCurrency(Currency currency)
        {
            var result = await $"depository/currencies".InternalApi()
                .PostJsonAsync<Currency>(currency);
            return result;
        }

        public async Task<CurrencyPair> CreateCurrencyPair(CurrencyPair pair)
        {
            var result = await $"depository/currency-pairs".InternalApi()
                .PostJsonAsync<CurrencyPair>(pair);
            return result;
        }


        public async Task CreateOrUpdateCurrencyAdapter(CurrencyAdapter currencyAdapter)
        {
            await $"depository/currency-adapters".InternalApi()
                .PostJsonAsync<CurrencyPair>(currencyAdapter);
        }

        /// <summary>
        /// Delete test currencies and their transactions
        /// Test currencies are currencies with codes starting with "Test_"
        /// </summary>
        public async Task<IFlurlResponse> DeleteTestCurrenciesPairsTransactions()
        {
            var result = await $"depository/currencies/test".InternalApi()
                .DeleteAsync();
            return result;
        }

        #endregion Currencies
    }
}
