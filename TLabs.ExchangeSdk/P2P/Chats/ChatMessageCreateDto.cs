using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Chats
{
    public class ChatMessageCreateDto
    {
        [Required]
        public Guid DealId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
