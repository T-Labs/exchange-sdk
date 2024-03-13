using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Chats
{
    public class ChatMessage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DealId { get; set; }

        /// <summary>Can be order.UserId, deal.DealUserId, deal.AppealAdminId or "system"</summary>
        [Required]
        public string UserId { get; set; }

        public Guid? ChatFileId { get; set; }

        public ChatFile ChatFile { get; set; }
        public string Text { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>True if message was read by the opposite user</summary>
        public bool WasRead { get; set; }

        private const string SystemUserId = "system";
        public bool IsSystemMessage => UserId == SystemUserId;
    }
}
