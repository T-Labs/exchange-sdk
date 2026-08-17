using System.Threading;
using System.Threading.Tasks;
using Audit.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TLabs.ExchangeSdk.Audit;

public static class AuditServiceCollectionExtensions
{
    public static IServiceCollection UseAudit(this IServiceCollection services, bool enabled)
    {
        services.AddSingleton<AuditInjectQueue>();
        services.AddSingleton<ExchangeAuditProvider>();
        services.AddHostedService<AuditInjectBackgroundService>();
        services.AddHostedService<AuditDataProviderInitializer>();
        Configuration.AuditDisabled = !enabled;
        AuditScopeLight.IsAuditActive = enabled;
        return services;
    }

    private sealed class AuditDataProviderInitializer : IHostedService
    {
        private readonly ExchangeAuditProvider _provider;

        public AuditDataProviderInitializer(ExchangeAuditProvider provider) =>
            _provider = provider;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Configuration.DataProvider = _provider;
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
