using Flurl.Http;
using System;
using System.Collections.Generic;
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

        public Task<QueryResult> SendTxCommand(TxCommandDto txCommand, bool checkBalances = true,
            bool use2StepTransfer = false) =>
            SendTxCommands(new List<TxCommandDto> { txCommand }, checkBalances, use2StepTransfer);

        public async Task<QueryResult> SendTxCommands(List<TxCommandDto> txCommands, bool checkBalances = true,
            bool use2StepTransfer = false)
        {
            foreach (var command in txCommands)
                command.Clean();
            var result = await $"depository/transaction/commands".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(checkBalances), checkBalances)
                .SetQueryParam(nameof(use2StepTransfer), use2StepTransfer)
                .PostJsonAsync(txCommands).GetQueryResult();
            return result;
        }

        public record TwoStepTxCommandsRequest(List<TxCommandDto> twoStepTxCommands,
            List<TxCommandDto> oneStepTxCommands);

        /// <summary>Create and save transactions in 2 steps, checking balance between steps</summary>
        /// <param name="twoStepTxCommands">tx commands that turn in 2 transactions and executed in 2 steps</param>
        /// <param name="oneStepTxCommands">optional signle-step transactions that will be added to second step</param>
        public async Task<List<TransactionDto>> SendTwoStepTxCommands(List<TxCommandDto> twoStepTxCommands,
            List<TxCommandDto> oneStepTxCommands = null)
        {
            oneStepTxCommands ??= new();
            foreach (var command in twoStepTxCommands)
                command.Clean();
            foreach (var command in oneStepTxCommands)
                command.Clean();

            var model = new TwoStepTxCommandsRequest(twoStepTxCommands, oneStepTxCommands);
            var result = await $"depository/transaction/two-step-commands".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .PostJsonAsync<List<TransactionDto>>(model);
            return result;
        }

        public async Task<PagedList<TransactionDto>> GetTransactions(string userId = null, string currencyCode = null,
            DateTimeOffset? from = null, DateTimeOffset? to = null,
            List<string> transactionTypes = null, int page = 1, int pageSize = 50000,
            bool includeRollbacks = false, string actionIdContains = null)
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
                .SetQueryParam(nameof(includeRollbacks), includeRollbacks.ToString())
                .SetQueryParam(nameof(actionIdContains), actionIdContains);
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

        public async Task<QueryResult<List<TransactionDto>>> GetTransactionsByAccountId(Guid accountId,
            DateTimeOffset? from = null, DateTimeOffset? to = null, List<string> transactionTypes = null)
        {
            var request = "depository/transaction/by-account".InternalApi()
                .SetQueryParam(nameof(accountId), accountId)
                .SetQueryParam(nameof(from), from?.RemoveTimePart().ToString("o"))
                .SetQueryParam(nameof(to), to?.RemoveTimePart().ToString("o"))
                .SetQueryParam(nameof(transactionTypes), transactionTypes);
            var result = await request.GetJsonAsync<List<TransactionDto>>().GetQueryResult();
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

        public async Task<List<Currency>> GetCurrencies(bool includeExchangeCurrencies = true,
            bool includeP2pExternalCurrencies = false)
        {
            var result = await $"depository/currencies".InternalApi()
                .SetQueryParam("includeExchangeCurrencies", includeExchangeCurrencies)
                .SetQueryParam("includeP2pExternalCurrencies", includeP2pExternalCurrencies)
                .GetJsonAsync<List<Currency>>().GetQueryResult();
            return result.Succeeded ? result.Data : new List<Currency>();
        }

        public async Task<Currency> CreateCurrency(Currency currency)
        {
            var result = await $"depository/currencies".InternalApi()
                .PostJsonAsync<Currency>(currency);
            return result;
        }

        public async Task<List<CurrencyPair>> GetCurrencyPairs()
        {
            var result = await $"depository/currency-pairs".InternalApi()
                .GetJsonAsync<List<CurrencyPair>>().GetQueryResult();
            return result.Succeeded ? result.Data : new List<CurrencyPair>();
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

        public async Task<string> Healthcheck() => await $"depository/healthcheck".InternalApi().GetStringAsync();
    }
}
