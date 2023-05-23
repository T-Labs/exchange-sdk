using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Helpdesk
{
    public class ClientHelpdesk
    {
        public ClientHelpdesk()
        {
        }

        public async Task<List<HelpdeskTicket>> GetTickets(string userId = null)
        {
            var result = await $"helpdesk/helpdesk".InternalApi()
                .SetQueryParam(nameof(userId), userId)
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
            await $"helpdesk/helpdesk/message".InternalApi()
                .PostJsonAsync(model);
        }

        public async Task ChangeStatus(Guid ticketId, HelpdeskTicketStatus status)
        {
            await $"helpdesk/helpdesk/{ticketId}/status".InternalApi()
                .SetQueryParam(nameof(status), (int)status)
                .PostJsonAsync(null);
        }
    }
}
