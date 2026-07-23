using System.Collections.Generic;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Audit
{
    public interface IClientAudit
    {
        Task<string> InjectAsync(string eventType, object auditEvent);
        Task<List<AuditEventDto>> GetAllAsync(AuditQueryOptions filter = null);
        Task<List<AuditEventDto>> GetByUserIdAsync(string userId, AuditQueryOptions filter = null);
    }
}
