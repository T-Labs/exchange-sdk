using System;

namespace TLabs.ExchangeSdk.Helpdesk
{
    public class HelpdeskTicketMessage
    {
        /// <summary>
        /// History id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ticket message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Is Admin Reply
        /// </summary>
        public bool IsReply { get; set; }

        /// <summary>
        /// Date message created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        public HelpdeskTicket HelpdeskTicket { get; set; }
    }
}
