using System;
using Newtonsoft.Json;

namespace TLabs.ExchangeSdk.Audit
{
    public class AuditEventDto
    {
        public string EventType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IP { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public AuditEventTargetDto Target { get; set; }
    }

    public class AuditEventTargetDto
    {
        public object SerializedNew { get; set; }
        public object SerializedOld { get; set; }
    }
}
