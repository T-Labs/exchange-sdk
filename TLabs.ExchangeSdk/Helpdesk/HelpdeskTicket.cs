using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.Helpdesk
{
    public class HelpdeskTicket
    {
        /// <summary>
        /// Ticket id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ticket number
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        /// <summary>
        /// Header
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Date ticket created
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Date ticket updated
        /// </summary>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public HelpdeskTicketStatus Status { get; set; }

        /// <summary>
        /// Ticket creator UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Last Message
        /// </summary>
        public string LastMessage { get; set; }

        /// <summary>
        /// History
        /// </summary>
        public List<HelpdeskTicketMessage> History { get; set; }
    }
}
