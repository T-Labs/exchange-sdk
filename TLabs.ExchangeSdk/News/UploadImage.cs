namespace TLabs.ExchangeSdk.News
{
    public class UploadImage
    {
        public string Extension { get; set; }
        public byte[] Data { get; set; }
        public long? NewsId { get; set; }
        public string? OldImageId { get; set; }
    }
}
