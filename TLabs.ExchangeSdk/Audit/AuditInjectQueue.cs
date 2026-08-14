using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Audit;

public sealed class AuditInjectQueue
{
    private const int Capacity = 1000;
    private static readonly TimeSpan SyncEnqueueWait = TimeSpan.FromSeconds(5);
    private long _droppedCount;
    private long _failedInjectCount;
    private readonly Channel<AuditInjectWorkItem> _channel = Channel.CreateBounded<AuditInjectWorkItem>(
        new BoundedChannelOptions(Capacity)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = false,
        });

    public ChannelReader<AuditInjectWorkItem> Reader => _channel.Reader;

    public long DroppedCount => Interlocked.Read(ref _droppedCount);

    public long FailedInjectCount => Interlocked.Read(ref _failedInjectCount);

    public bool TryEnqueue(string eventType, string payload) =>
        TryEnqueueWithWait(eventType, payload, SyncEnqueueWait);

    public bool TryEnqueueWithWait(string eventType, string payload, TimeSpan waitTimeout)
    {
        var item = new AuditInjectWorkItem(eventType, payload);
        if (_channel.Writer.TryWrite(item))
            return true;

        try
        {
            using var cts = new CancellationTokenSource(waitTimeout);
            return EnqueueAsync(eventType, payload, cts.Token).AsTask().GetAwaiter().GetResult();
        }
        catch (OperationCanceledException)
        {
            RecordDrop();
            return false;
        }
    }

    public async ValueTask<bool> EnqueueAsync(
        string eventType,
        string payload,
        CancellationToken cancellationToken = default)
    {
        var item = new AuditInjectWorkItem(eventType, payload);
        while (await _channel.Writer.WaitToWriteAsync(cancellationToken))
        {
            if (_channel.Writer.TryWrite(item))
                return true;
        }

        RecordDrop();
        return false;
    }

    public long RecordDrop() => Interlocked.Increment(ref _droppedCount);

    public long RecordFailedInject() => Interlocked.Increment(ref _failedInjectCount);

    public void Complete() => _channel.Writer.TryComplete();
}

public sealed record AuditInjectWorkItem(string EventType, string Payload);
