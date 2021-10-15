using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
