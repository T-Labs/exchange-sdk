using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News;

public class NewsVersion
{
    [Key]
    public long Id { get; set; }

    public long NewsItemId { get; set; }

    public string Title { get; set; }
    public string Preview { get; set; }
    public string Body { get; set; }

    /// <summary> Image id with extension </summary>
    public string ImageId { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public override string ToString()
    {
        return
            $"Title: {Title}, Preview: {Preview}, Body: {Body}, ImageId: {ImageId}";
    }
}
