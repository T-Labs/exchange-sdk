using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

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
                IConnection conn = factory.CreateConnection();
                IModel channel = conn.CreateModel();
                channel.QueueDeclare(queue, true, false, false, null);
                channel.BasicPublish("", queue, null, Encoding.UTF8.GetBytes(json));
                conn.Close();
                _logger.LogInformation($"RabbitMq sent to {requestInfo}");
                return QueryResult.CreateSucceeded();
            }
            catch (Exception e)
            {
                _logger.LogError(e, requestInfo);
                return QueryResult.CreateFailed($"{e.Message}\n  {requestInfo}");
            }
        }

        public void SendEmailToAdmins(string subject, string text)
        {
            Send(RabbitMqQueues.Notifications, new NotificationEmail
            {
                To = "",
                Subject = subject,
                HtmlBody = text,
                Body = text.Replace("<br/>", "\n"),
                UserGroup = UserGroup.Admins,
            });
        }
    }
}
