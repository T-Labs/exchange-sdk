using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Audit
{
    public class AuditEventsPageDto
    {
        public List<AuditEventDto> Items { get; set; } = new();

        public int Total { get; set; }
    }
}
