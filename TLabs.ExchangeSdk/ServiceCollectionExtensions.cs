using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSdkServices(this IServiceCollection services)
        {
            services.AddTransient<Commissions.ClientCommissions>();
            services.AddTransient<CryptoAdapters.ClientCryptoAdapters>();
            services.AddTransient<Depository.ClientDepository>();
            services.AddTransient<Deposits.ClientDeposits>();
            services.AddTransient<Exchanges.ClientExchanges>();
            services.AddTransient<Trading.ClientMarketdata>();
            services.AddTransient<Trading.ClientTradingBrokerage>();
            services.AddTransient<Users.ClientUsers>();

            // needs activation in Program.cs and action /currencies/reload
            services.AddSingleton<Currencies.CurrenciesCache>(); 
        }
    }
}
