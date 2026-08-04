using System;
using System.Threading;
using System.Threading.Tasks;
using Audit.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TLabs.ExchangeSdk.Audit;

[CLSCompliant(false)]
public class ExchangeAuditProvider : AuditDataProvider
{
    private readonly AuditInjectQueue _queue;
    private readonly ILogger<ExchangeAuditProvider> _logger;

    public ExchangeAuditProvider(
        AuditInjectQueue queue,
        ILogger<ExchangeAuditProvider> logger)
    {
        _queue = queue;
        _logger = logger;
    }

    public override object InsertEvent(AuditEvent auditEvent)
    {
        Enqueue(auditEvent);
        return string.Empty;
    }

    public override async Task<object> InsertEventAsync(
        AuditEvent auditEvent,
        CancellationToken cancellationToken = default)
    {
        await EnqueueAsync(auditEvent, cancellationToken);
        return string.Empty;
    }

    private void Enqueue(AuditEvent auditEvent)
    {
        var eventType = auditEvent.EventType;
        var payload = JsonConvert.SerializeObject(auditEvent);
        if (_queue.TryEnqueue(eventType, payload))
            return;

        _logger.LogError(
            "Audit inject queue full after wait, dropping event {EventType}. Total dropped: {DroppedCount}",
            eventType,
            _queue.DroppedCount);
    }

    private async Task EnqueueAsync(AuditEvent auditEvent, CancellationToken cancellationToken)
    {
        var eventType = auditEvent.EventType;
        var payload = JsonConvert.SerializeObject(auditEvent);
        if (await _queue.EnqueueAsync(eventType, payload, cancellationToken))
            return;

        _logger.LogError(
            "Audit inject queue full, dropping event {EventType}. Total dropped: {DroppedCount}",
            eventType,
            _queue.DroppedCount);
    }
}
