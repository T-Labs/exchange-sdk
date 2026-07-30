using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Audit
{
    public interface IClientAudit
    {
        Task<string> InjectAsync(string eventType, object auditEvent, CancellationToken cancellationToken = default);
        Task<List<AuditEventDto>> GetAllAsync(AuditQueryOptions filter = null, CancellationToken cancellationToken = default);
        Task<List<AuditEventDto>> GetByUserIdAsync(string userId, AuditQueryOptions filter = null, CancellationToken cancellationToken = default);
    }
}
