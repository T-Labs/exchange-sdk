using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.P2P.Chats
{
    public class ChatFile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ChatMessageId { get; set; }

        [Required]
        public string Extension { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}
