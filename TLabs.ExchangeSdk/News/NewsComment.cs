using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.News;

public class NewsComment
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public string Text { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public long? NewsItemId { get; set; }
    public NewsItem NewsItem { get; set; }

    public string CurrencyListingCode { get; set; }

    public List<CommentLike> CommentLikes { get; set; }

    [NotMapped]
    public string UserNickname { get; set; }
}
