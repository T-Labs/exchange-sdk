using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace TLabs.ExchangeSdk.Farming;

public class TenantSettings
{
    [Key]
    public long Id { get; set; }

    public long TenantId { get; set; }
    public Tenant Tenant { get; set; }
    public bool IsShowMiniGame { get; set; }
    public string ColorSettingsJson { get; set; }


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

public enum ColorSetting
{
    colorTertiary200 = 1000,
}
