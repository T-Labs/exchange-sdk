using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News
{
    public class Image
    {
        [Key]
        public string Id { get; set; }

        public byte[] Data { get; set; }

        public static string GetUrl(string imageId) =>
            string.IsNullOrWhiteSpace(imageId) ? "" : $"/news/image/{imageId}";
    }
}
