using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.BinanceHandling
{
    public class ClientBinanceHandling
    {
        private readonly ILogger _logger;

        private const string BaseUrl = "brokerage/binance-handling";
        public const string PaymentCurrency = "C3";

        public ClientBinanceHandling(
            ILogger<ClientBinanceHandling> logger)
        {
            _logger = logger;
        }

        public async Task<List<BinanceHandlingAccount>> GetAccounts(string userId = null, BinanceHandlingBot? bot = null,
            string mainCurrency = null)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(bot), bot.HasValue ? (int)bot : "")
                .SetQueryParam(nameof(mainCurrency), mainCurrency)
                .GetJsonAsync<List<BinanceHandlingAccount>>();
            return result;
        }

        public async Task<BinanceHandlingAccount> AddAccount(BinanceHandlingAccount account)
        {
            var result = await $"{BaseUrl}".InternalApi()
                .PostJsonAsync<BinanceHandlingAccount>(account);
            return result;
        }

        public async Task<List<BinanceBalanceSnapshot>> GetBalanceSnapshots(Guid accountId)
        {
            var result = await $"{BaseUrl}/balance-snapshots".InternalApi()
                .SetQueryParam(nameof(accountId), accountId)
                .GetJsonAsync<List<BinanceBalanceSnapshot>>();
            return result;
        }

        public async Task<List<BinanceHandlingPayment>> GetPayments(Guid? accountId = null,
            DateTimeOffset? from = null, DateTimeOffset? to = null)
        {
            var result = await $"{BaseUrl}/payments".InternalApi()
                .SetQueryParam(nameof(accountId), accountId)
                .SetQueryParam(nameof(from), from?.ToString("o"))
                .SetQueryParam(nameof(to), to?.ToString("o"))
                .GetJsonAsync<List<BinanceHandlingPayment>>();
            return result;
        }

        public async Task<BinanceHandlingPayment> GetPayment(Guid paymentId)
        {
            var result = await $"{BaseUrl}/payments/{paymentId}".InternalApi()
                .GetJsonAsync<BinanceHandlingPayment>();
            return result;
        }

        public async Task<BinanceHandlingPayment> CreateCustomPayment(BinanceHandlingPayment payment)
        {
            var result = await $"{BaseUrl}/payments/{payment.Id}".InternalApi()
                .PostJsonAsync<BinanceHandlingPayment>(payment);
            return result;
        }

        public async Task<BinanceHandlingPayment> EditPayment(BinanceHandlingPayment editedPayment)
        {
            var result = await $"{BaseUrl}/payments/{editedPayment.Id}".InternalApi()
                .PutJsonAsync<BinanceHandlingPayment>(editedPayment);
            return result;
        }

        public async Task<BinanceHandlingPayment> ConfirmPayment(Guid paymentId)
        {
            var result = await $"{BaseUrl}/payments/{paymentId}/confirmation".InternalApi()
                .PostJsonAsync<BinanceHandlingPayment>(null);
            return result;
        }
    }
}
