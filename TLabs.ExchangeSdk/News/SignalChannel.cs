using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News
{
    public class SignalChannel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name_en { get; set; }

        [Required]
        public string Name_ru { get; set; }
    }
}
