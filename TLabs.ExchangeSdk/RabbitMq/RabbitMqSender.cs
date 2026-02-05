using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Users;

namespace TLabs.ExchangeSdk.RabbitMq
{
    /// <summary>Requires "RabbitMqConnection" in appsettings</summary>
    public class RabbitMqSender
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public RabbitMqSender(IConfiguration configuration,
            ILogger<RabbitMqSender> logger)
        {
            _config = configuration;
            _logger = logger;
        }

        public QueryResult Send(string queue, Message message)
        {
            if (message.Id == Guid.Empty)
                message.Id = Guid.NewGuid();
            message.Created = DateTimeOffset.UtcNow;

            string urlRabbitMq = _config["RabbitMqConnection"];
            string json = JsonConvert.SerializeObject(message);
            string requestInfo = $"queue:{queue}, json:{json}, url:{urlRabbitMq}";
            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                factory.Uri = new Uri(urlRabbitMq);
                using IConnection conn = factory.CreateConnection();
                using IModel channel = conn.CreateModel();
                channel.QueueDeclare(queue, true, false, false, null);
                channel.BasicPublish("", queue, null, Encoding.UTF8.GetBytes(json));
                _logger.LogInformation($"RabbitMq sent to {requestInfo}");
                return QueryResult.CreateSucceeded();
            }
            catch (Exception e)
            {
                _logger.LogError(e, requestInfo);
                return QueryResult.CreateFailed($"{e.Message}\n  {requestInfo}");
            }
        }

        public QueryResult SendEmailTemplate(string email, string templateName, Dictionary<string, string> arguments = null,
            string language = "en", UserGroup userGroup = UserGroup.SingleUser)
        {
            NotificationEmailTemplate emailTemplateMessage = new NotificationEmailTemplate
            {
                UserGroup = userGroup,
                TemplateName = templateName,
                Locale = language,
                To = email,
                Arguments = arguments ?? new(),
            };

            var result = Send(RabbitMqQueues.Notifications, emailTemplateMessage);
            return result;
        }

        public QueryResult SendEmailToAdmins(string subject, string text)
        {
            return Send(RabbitMqQueues.Notifications, new NotificationEmail
            {
                To = "",
                Subject = subject,
                HtmlBody = text,
                Body = text.Replace("<br/>", "\n"),
                UserGroup = UserGroup.Admins,
            });
        }

        public QueryResult SendSms(string phone, string message)
        {
            var sms = new NotificationSMS
            {
                Phone = phone,
                Text = message
            };
            return Send(RabbitMqQueues.Notifications, sms);
        }

        public QueryResult NotifyAdminsAboutLogInError(ApplicationUser user, string ip, bool isLockSucceeded)
        {
            DateTime time = DateTime.UtcNow;
            string text = "";
            if (isLockSucceeded)
                text += $"The following admin failed to log in and was blocked:";
            else
                text += $"The following admin failed to log in, and system wasn't able to block him:";
            text += $" <br/><br/>User Id: {user.Id}<br/>Username: {user.UserName}<br/>User Email: {user.Email}<br/> Ip:{ip}<br/>Date: {time.ToString("G")}";
            string subject = "Stock.All: Admin failed to log in";
            return SendEmailToAdmins(subject, text);
        }
    }
}
