namespace TLabs.ExchangeSdk.Farming.Dtos;

public class TenantDataDto
{
    public string ExchangeUserId { get; set; }

    public string BotToken { get; set; }

    public string ProjectName { get; set; }
    public string TokenName { get; set; }

    public string TokenLogoIconId { get; set; }
    public string ProjectLogoIconId { get; set; }
    public string MiniGameLogoIconId { get; set; }
    public string FriendsLogoIconId { get; set; }

    public string Url { get; set; }

    public int FarmingTimeHours { get; set; }
    public bool IsShowMiniGame { get; set; }
    public string ColorSettingsJson { get; set; }
    public int? MaxNumberOfInvites { get; set; }
    public int TokenDecimalPlaces { get; set; }
}
