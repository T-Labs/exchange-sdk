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
        public DateTime Created { get; set; }

        /// <summary>
        /// Date ticket updated
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public HelpdeskTicketStatus Status { get; set; }

        /// <summary>
        /// Ticket creator UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Ticket creator UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Last Message
        /// </summary>
        public string LastMessage { get; set; }

        /// <summary>
        /// History
        /// </summary>
        public List<HelpdeskTicketHistory> History { get; set; }
    }

    public class HelpdeskTicketHistory
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
        public DateTime Created { get; set; }

        public HelpdeskTicket HelpdeskTicket { get; set; }
    }

    public enum HelpdeskTicketStatus
    {
        Created = 0,

        InProgress = 1,

        Closed = 2
    }
}
