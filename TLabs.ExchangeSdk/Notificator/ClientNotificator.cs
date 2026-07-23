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
        /// Enqueues a template email in Notificator (outbox). Returns when the row is persisted; HTTP status may be 202 Accepted.
        /// Poll or use a status endpoint if you need to confirm delivery — <see cref="EmailDispatchResponse.Status"/> may be <c>Pending</c> until the worker sends.
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
        /// Enqueues via Notificator HTTP API (same payload shape as Rabbit). Delivery is asynchronous — response often has <c>Status = "Pending"</c> (HTTP 202).
        /// </summary>
        public async Task<EmailDispatchResponse> SendTemplateEmail(NotificationEmailTemplate request)
        {
            return await "notificator/emails/templates"
                .InternalApi()
                .PostJsonAsync(request)
                .ReceiveJson<EmailDispatchResponse>();
        }

        /// <summary>
        /// Re-queues a dispatch for the background worker. SMTP is not run in-band on the API.
        /// </summary>
        [Obsolete("processImmediately is ignored by the server; use RetryTemplateEmail(id)")]
        public async Task<EmailDispatchResponse> RetryTemplateEmail(Guid id, bool processImmediately = true)
        {
            return await RetryTemplateEmail(id);
        }

        public async Task<EmailDispatchResponse> RetryTemplateEmail(Guid id)
        {
            return await $"notificator/emails/{id}/retry"
                .InternalApi()
                .PostAsync()
                .ReceiveJson<EmailDispatchResponse>();
        }

        public async Task<VerificationReminderDispatchResponse> SendVerificationReminderToUnverifiedUsers(
            SendVerificationReminderRequest request = null)
        {
            return await "notificator/emails/verification-reminders/unverified"
                .InternalApi()
                .PostJsonAsync(request ?? new SendVerificationReminderRequest())
                .ReceiveJson<VerificationReminderDispatchResponse>();
        }
    }
}
