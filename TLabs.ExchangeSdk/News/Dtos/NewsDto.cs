namespace TLabs.ExchangeSdk.News.Dtos;

public class NewsDto
{
    public long? NewsItemId { get; set; }
    public string CurrencyListingCode { get; set; }
    public Language Language { get; set; }
    public string Title { get; set; }
    public string Preview { get; set; }
    public string Body { get; set; }
    public string ImageId { get; set; }

    public override string ToString()
    {
        return $"NewsItemId: {NewsItemId}, CurrencyListingCode: {CurrencyListingCode}, Language: {Language}, " +
               $"Title: {Title}, Preview: {Preview}, Body: {Body}, ImageId: {ImageId}";
    }
}
