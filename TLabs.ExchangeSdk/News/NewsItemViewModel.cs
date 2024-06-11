using System;
using System.Linq;

namespace TLabs.ExchangeSdk.News
{
    public class NewsItemViewModel
    {
        public long Id { get; set; }

        public Language Language { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Preview { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        /// <summary> Image id with extension </summary>
        public string ImageId { get; set; }

        /// <summary> Image binary data </summary>
        public string ImageUrl { get; set; }

        public NewsItemViewModel()
        {
        }

        public NewsItemViewModel(NewsItem news)
        {
            var lastVersion = news.NewsVersions.Last();

            Id = news.Id;
            Language = news.Language;
            Title = lastVersion.Title;
            Body = lastVersion.Body;
            Preview = lastVersion.Preview;
            DateCreated = lastVersion.DateCreated;
            ImageId = lastVersion.ImageId;
            ImageUrl = Image.GetUrl(lastVersion.ImageId);
        }
    }
}
