using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TLabs.ExchangeSdk.Audit;

internal sealed class AuditInjectBackgroundService : BackgroundService
{
    private const int MaxInjectAttempts = 3;
    private readonly AuditInjectQueue _queue;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<AuditInjectBackgroundService> _logger;

    public AuditInjectBackgroundService(
        AuditInjectQueue queue,
        IServiceScopeFactory scopeFactory,
        ILogger<AuditInjectBackgroundService> logger)
    {
        _queue = queue;
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var item in _queue.Reader.ReadAllAsync(stoppingToken))
            await InjectWithRetryAsync(item, stoppingToken);
    }

    private async Task InjectWithRetryAsync(AuditInjectWorkItem item, CancellationToken stoppingToken)
    {
        for (var attempt = 1; attempt <= MaxInjectAttempts; attempt++)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var eventId = await scope.ServiceProvider
                    .GetRequiredService<IClientAudit>()
                    .InjectAsync(item.EventType, item.Payload, stoppingToken);

                if (!string.IsNullOrEmpty(eventId))
                    return;

                _logger.LogWarning(
                    "Audit inject returned empty for {EventType}, attempt {Attempt}/{MaxAttempts}",
                    item.EventType,
                    attempt,
                    MaxInjectAttempts);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Background audit inject failed for {EventType}, attempt {Attempt}/{MaxAttempts}",
                    item.EventType,
                    attempt,
                    MaxInjectAttempts);
            }

            if (attempt < MaxInjectAttempts)
                await Task.Delay(TimeSpan.FromSeconds(attempt), stoppingToken);
        }

        _logger.LogError(
            "Audit inject permanently failed for {EventType}. Total failed: {FailedCount}",
            item.EventType,
            _queue.RecordFailedInject());
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _queue.Complete();
        await base.StopAsync(cancellationToken);
    }
}
