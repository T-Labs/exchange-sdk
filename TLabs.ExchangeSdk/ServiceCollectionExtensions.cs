using Microsoft.Extensions.DependencyInjection;

namespace TLabs.ExchangeSdk
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSdkServices(this IServiceCollection services)
        {
            services.AddTransient<Affiliate.ClientAffiliate>();
            services.AddTransient<BinanceHandling.ClientBinanceHandling>();
            services.AddTransient<CashDeposits.ClientCashDeposits>();
            services.AddTransient<Commissions.ClientCommissions>();

            services.AddTransient<Currencies.ClientCurrencies>();
            services.AddTransient<Currencies.CurrencyListings.ClientCurrencyListings>();
            services.AddTransient<CurrencyOfferings.ClientCurrencyOfferings>();

            services.AddTransient<CryptoAdapters.ClientCryptoAdapters>();
            services.AddTransient<CryptoAdapters.Tron.ClientCryptoAdapterTron>();
            services.AddTransient<CryptoAdapters.NownodesApi.ClientCryptoNownodes>();
            services.AddTransient<CryptoAdapters.Tron.ClientCryptoAdapterOrgon>();

            services.AddTransient<Depository.ClientDepository>();
            services.AddTransient<Deposits.ClientDeposits>();
            services.AddTransient<ExternalPayments.ClientExternalPayments>();
            services.AddTransient<Exchanges.ClientExchanges>();
            services.AddTransient<Helpdesk.ClientHelpdesk>();
            services.AddTransient<LiquidityImport.ClientLiquidityConnectors>();
            services.AddTransient<LiquidityImport.ClientLiquidityMain>();
            services.AddTransient<Ordering.ClientOrdering>();
            services.AddTransient<RabbitMq.RabbitMqSender>();
            services.AddTransient<RabbitMq.EmailTemplateSender>();
            services.AddTransient<Staking.ClientStaking>();

            services.AddTransient<Trading.ClientMarketdata>();
            services.AddTransient<Trading.ClientMatchingEngine>();
            services.AddTransient<Trading.ClientTradingBrokerage>();

            services.AddTransient<Users.ClientUsers>();
            services.AddTransient<Users.IIPService, Users.IPService>();
            services.AddTransient<Verification.ClientVerifications>();

            services.AddTransient<Withdrawals.ClientWithdrawals>();
            services.AddTransient<P2P.ClientP2P>();
            services.AddTransient<Bwp.ClientBwp>();
            services.AddTransient<WebApp.ClientWebapp>();
            services.AddTransient<News.ClientNews>();

            services.AddTransient<Farming.ClientFarming>();
            services.AddTransient<Farming.ClientFarmingAdmin>();

            // needs activation in Program.cs and action /currencies/reload
            services.AddSingleton<Currencies.CurrenciesCache>();
            services.AddSingleton<Farming.TenantsCache>();
        }
    }
}
