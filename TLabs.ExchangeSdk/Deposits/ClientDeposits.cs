using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using Flurl.Http;

namespace TLabs.ExchangeSdk.Deposits
{
    /// <summary>Client for module Brokerage.Refill</summary>
    public class ClientDeposits
    {
        public async Task<IFlurlResponse> Deposit(DepositDto deposit)
        {
            var result = await $"cashrefill/crypto/refill".InternalApi()
                .PostJsonAsync(deposit);
            return result;
        }
    }
}
