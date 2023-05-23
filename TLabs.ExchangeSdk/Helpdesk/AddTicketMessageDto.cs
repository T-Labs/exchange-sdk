using System;

namespace TLabs.ExchangeSdk.Helpdesk
{
    public class AddTicketMessageDto
    {
        public Guid TicketId { get; set; }
        public bool isAdminReply { get; set; }
        public string Message { get; set; }
    }
}
