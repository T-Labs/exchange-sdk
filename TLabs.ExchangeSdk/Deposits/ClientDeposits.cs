using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using Flurl.Http;

namespace TLabs.ExchangeSdk.Deposits
{
    /// <summary>Client for deposits module (hosted in stock-withdrawals)</summary>
    public class ClientDeposits
    {
        public async Task<IFlurlResponse> Deposit(DepositDto deposit)
        {
            var result = await $"withdrawals/deposits".InternalApi()
                .PostJsonAsync(deposit);
            return result;
        }

        public async Task<IFlurlResponse> AddAdminDeposit(string userId, decimal amount, string currencyCode)
        {
            var result = await Deposit(new DepositDto
            {
                Type = DepositType.FromAdmin,
                Amount = amount,
                CurrencyCode = currencyCode,
                UserId = userId,
                TxId = $"{nameof(DepositType.FromAdmin)}_{Guid.NewGuid()}",
            });
            return result;
        }
    }
}
