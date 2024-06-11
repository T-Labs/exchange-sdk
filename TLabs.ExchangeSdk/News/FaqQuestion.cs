using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News
{
    public class FaqQuestion
    {
        [Key]
        public int Id { get; set; }

        public Language Language { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
    }
}
