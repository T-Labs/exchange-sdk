using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

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
            return await SendTemplateEmail(new SendTemplateEmailRequest
            {
                To = to,
                TemplateName = templateName,
                Locale = locale,
                Arguments = arguments,
            });
        }

        /// <summary>
        /// Sends a template email through Notificator WebAPI.
        /// </summary>
        public async Task<EmailDispatchResponse> SendTemplateEmail(SendTemplateEmailRequest request)
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
                .PostJsonAsync(new RetryEmailRequest { ProcessImmediately = processImmediately })
                .ReceiveJson<EmailDispatchResponse>();
        }
    }
}
