using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News;

public class CommentLike
{
    [Required]
    public long CommentId { get; set; }

    [Required]
    public string UserId { get; set; }
}
