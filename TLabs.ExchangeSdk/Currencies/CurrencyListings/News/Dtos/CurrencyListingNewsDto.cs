using System.ComponentModel.DataAnnotations;
using TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Models;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Dtos;

public class CurrencyListingNewsDto
{
    [Required]
    public string CurrencyCode { get; set; }

    public Language Language { get; set; }
    public string Title { get; set; }
    public string Preview { get; set; }
    public string Body { get; set; }
    public string ImageId { get; set; }

    public override string ToString()
    {
        return
            $"CurrencyCode: {CurrencyCode}, Language: {Language}, Title: {Title}, Preview: {Preview}, Body: {Body}, ImageId: {ImageId}";
    }
}
