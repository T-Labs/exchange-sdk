using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TLabs.ExchangeSdk.Farming;

public class Tenant
{
    [Key]
    [JsonIgnore]
    public long Id { get; set; }

    [Required]
    public string ExchangeUserId { get; set; }

    [Required]
    public string BotToken { get; set; }

    [Required]
    public string ProjectName { get; set; }
 
    public string? ProjectLogoIconId { get; set; }

    public string? TokenLogoIconId { get; set; }

    [Required]
    public string TokenName { get; set; }
}
