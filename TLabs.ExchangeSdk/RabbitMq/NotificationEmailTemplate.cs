using System;
using System.Collections.Generic;

namespace TLabs.ExchangeSdk.RabbitMq
{
    public class NotificationEmailTemplate : NotificationMessage
    {
        public NotificationEmailTemplate()
        {
            Type = NotificationMessageType.EMailTemplate;
        }

        public string TemplateName { get; set; }
        public string Locale { get; set; }
        public string To { get; set; }
        public Dictionary<string, string> Arguments { get; set; }

        /// <summary>Optional: absolute expiry for Notificator outbox retries (UTC).</summary>
        public DateTimeOffset? ExpiresAt { get; set; }

        /// <summary>Optional: cap SMTP retry attempts for this dispatch in Notificator.</summary>
        public int? MaxAttempts { get; set; }
    }
}
