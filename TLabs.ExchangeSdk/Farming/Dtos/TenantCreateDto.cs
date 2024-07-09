namespace TLabs.ExchangeSdk.Farming.Dtos;

public class TenantCreateDto
{
    public string ExchangeUserId { get; set; }
    public string BotToken { get; set; }
    public string ProjectName { get; set; }
    public string ProjectLogoIconId { get; set; }
    public string TokenLogoIconId { get; set; }
    public string TokenName { get; set; }
    public string Url { get; set; }
    public bool IsShowMiniGame { get; set; }
    public string ColorSettingsJson { get; set; }
}
