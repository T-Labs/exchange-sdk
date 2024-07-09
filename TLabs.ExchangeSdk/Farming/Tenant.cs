using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
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

    public string Url { get; set; }

    public bool IsShowMiniGame { get; set; }

    public string ColorSettingsJson { get; private set; }

    public Dictionary<string, string> GetColorSettings()
    {
        if (string.IsNullOrEmpty(ColorSettingsJson))
            return new Dictionary<string, string>();

        return JsonSerializer.Deserialize<Dictionary<string, string>>(ColorSettingsJson);
    }

    public void SetColorSettings(Dictionary<string, string> colorSettings)
    {
        ColorSettingsJson = JsonSerializer.Serialize(colorSettings);
    }

    public string GetColor(string colorName)
    {
        var settings = GetColorSettings();
        return settings.GetValueOrDefault(colorName);
    }

    public void SetColor(string colorName, string colorValue)
    {
        var settings = GetColorSettings();
        settings[colorName] = colorValue;
        SetColorSettings(settings);
    }
}
