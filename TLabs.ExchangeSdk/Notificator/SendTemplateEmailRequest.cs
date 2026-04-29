using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Notificator
{
    public class SendTemplateEmailRequest
    {
        public string To { get; set; }

        public string TemplateName { get; set; }

        public string Locale { get; set; }

        public Dictionary<string, string> Arguments { get; set; }
    }
}
