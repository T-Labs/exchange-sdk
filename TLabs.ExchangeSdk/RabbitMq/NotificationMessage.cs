using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.RabbitMq
{
    public class NotificationMessage : Message
    {
        public NotificationMessageType Type { get; set; }
        public UserGroup UserGroup { get; set; } = UserGroup.SingleUser;
    }

    public enum NotificationMessageType { EMail = 1, SMS = 2, EMailTemplate = 3 }

    public enum UserGroup { SingleUser = 1, Admins = 2 }

    public class NotificationSMS : NotificationMessage
    {
        public NotificationSMS()
        {
            Type = NotificationMessageType.SMS;
        }

        public string Phone { get; set; }
        public string Text { get; set; }
    }

    public class NotificationEmail : NotificationMessage
    {
        public NotificationEmail()
        {
            Type = NotificationMessageType.EMail;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string HtmlBody { get; set; }

        public override string ToString() =>
            $"{nameof(NotificationEmail)}(to {To}, {Subject}, \nHtmlBody: {HtmlBody}\nBody: {Body})";
    }
}
