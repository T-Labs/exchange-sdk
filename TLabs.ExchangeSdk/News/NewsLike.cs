using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News;

public class NewsLike
{
    [Required]
    public long NewsItemId { get; set; }

    [Required]
    public string UserId { get; set; }
}
