using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.ExchangeSdk.Commissions;
using TLabs.ExchangeSdk.Currencies;
using TLabs.ExchangeSdk.Depository;
using TLabs.ExchangeSdk.Trading;
using TLabs.ExchangeSdk.Users;

namespace TLabs.ExchangeSdk
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSdkServices(this IServiceCollection services)
        {
            services.AddTransient<ClientCommissions>();
            services.AddTransient<ClientDepository>();
            services.AddTransient<ClientMarketdata>();
            services.AddTransient<ClientTradingBrokerage>();
            services.AddTransient<ClientUsers>();

            // needs activation in Program.cs and action /currencies/reload
            services.AddSingleton<CurrenciesCache>(); 
        }
    }
}
