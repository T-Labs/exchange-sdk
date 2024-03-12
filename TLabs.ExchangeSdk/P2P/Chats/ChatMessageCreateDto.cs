using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Chats
{
    public class ChatMessageCreateDto
    {
        [Required]
        public Guid DealId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Text { get; set; }
    }
}
