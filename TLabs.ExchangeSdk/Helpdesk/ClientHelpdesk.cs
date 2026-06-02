using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Helpdesk
{
    public class ClientHelpdesk
    {
        public ClientHelpdesk()
        {
        }

        public async Task<byte[]> GetFile(Guid fileId)
        {
            return await $"helpdesk/files/{fileId}".InternalApi().GetBytesAsync();
        }

        public async Task<Guid> UploadFile(IFormFile file)
        {
            var uploadFileResponse = await "helpdesk/files".InternalApi().PostMultipartAsync((content) =>
            {
                content.AddFile("file", file.OpenReadStream(), file.FileName, file.ContentType);
            });
            var fileId = await uploadFileResponse.GetJsonAsync<Guid>();

            return fileId;
        }

        public async Task<List<HelpdeskTicket>> GetTickets(string userId = null, bool? escalatedToDevelopers = null)
        {
            var result = await $"helpdesk/helpdesk".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(escalatedToDevelopers), escalatedToDevelopers)
                .GetJsonAsync<List<HelpdeskTicket>>();
            return result;
        }

        public async Task<HelpdeskTicket> GetTicket(Guid id)
        {
            var result = await $"helpdesk/helpdesk/{id}".InternalApi()
                .GetJsonAsync<HelpdeskTicket>();
            return result;
        }

        public async Task AddTicket(HelpdeskTicket ticket)
        {
            await $"helpdesk/helpdesk".InternalApi()
                .PostJsonAsync(ticket);
        }

        public async Task AddMessage(AddTicketMessageDto model)
        {
            await $"helpdesk/helpdesk/messages".InternalApi()
                .PostJsonAsync(model);
        }

        public async Task ChangeStatus(Guid ticketId, HelpdeskTicketStatus status)
        {
            await $"helpdesk/helpdesk/{ticketId}/status".InternalApi()
                .SetQueryParam(nameof(status), (int)status)
                .PostJsonAsync(null);
        }

        public async Task<QueryResult> EscalateToDevelopers(Guid ticketId) =>
            await $"helpdesk/helpdesk/{ticketId}/escalate".InternalApi()
                .PostJsonAsync(null)
                .GetQueryResult();

        public async Task<string> Healthcheck() =>
            await $"helpdesk/healthcheck".InternalApi().GetStringAsync();
    }
}
