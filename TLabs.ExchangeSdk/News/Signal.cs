using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News
{
    public class Signal
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public Language Language { get; set; }

        [Required]
        public string Title { get; set; }

        public string Text { get; set; }

        public int? ChannelId { get; set; }
        public SignalChannel Channel { get; set; }
    }
}
