using System;
using Newtonsoft.Json;

namespace TLabs.ExchangeSdk.Audit;

public class AuditEventDto
{
    public string EventType { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string UserId { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string IP { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string UserAgent { get; set; }

    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public int Duration { get; set; }

    public string EventData { get; set; }

    public AuditEventTargetDto Target { get; set; }
}

[JsonConverter(typeof(AuditEventTargetDtoConverter))]
public class AuditEventTargetDto
{
    [JsonProperty("New")]
    public string SerializedNew { get; set; }

    [JsonProperty("Old")]
    public string SerializedOld { get; set; }
}
