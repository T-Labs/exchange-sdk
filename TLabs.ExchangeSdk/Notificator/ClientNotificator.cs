using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.RabbitMq;

namespace TLabs.ExchangeSdk.Notificator
{
    public class ClientNotificator
    {
        /// <summary>
        /// Sends a template email through Notificator WebAPI.
        /// The request is persisted in Notificator outbox before delivery.
        /// </summary>
        public async Task<EmailDispatchResponse> SendTemplateEmail(
            string to,
            string templateName,
            Dictionary<string, string> arguments = null,
            string locale = null)
        {
            return await SendTemplateEmail(new NotificationEmailTemplate
            {
                To = to,
                TemplateName = templateName,
                Locale = locale,
                Arguments = arguments,
            });
        }

        /// <summary>
        /// Sends a template email through Notificator WebAPI. The payload matches <see cref="NotificationEmailTemplate"/>
        /// used for RabbitMQ notifications; extra message fields are ignored by the HTTP API.
        /// </summary>
        public async Task<EmailDispatchResponse> SendTemplateEmail(NotificationEmailTemplate request)
        {
            return await "notificator/emails/template"
                .InternalApi()
                .PostJsonAsync(request)
                .ReceiveJson<EmailDispatchResponse>();
        }

        /// <summary>
        /// Retries an existing email dispatch request.
        /// </summary>
        public async Task<EmailDispatchResponse> RetryTemplateEmail(Guid id, bool processImmediately = true)
        {
            return await $"notificator/emails/{id}/retry"
                .InternalApi()
                .SetQueryParam("processImmediately", processImmediately)
                .PostAsync()
                .ReceiveJson<EmailDispatchResponse>();
        }
    }
}
