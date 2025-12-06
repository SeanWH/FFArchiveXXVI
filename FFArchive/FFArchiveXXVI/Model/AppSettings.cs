namespace FFArchiveXXVI.Model;

using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class AppSettings
{
    public const string SettingsFileName = "appsettings.json";

    [JsonInclude]
    public string SavePath { get; set; } = "";

    [JsonInclude]
    public bool UseCompression { get; set; } = false;

    [JsonInclude]
    public bool SaveDocumentAsHtml { get; set; } = true;

    [JsonInclude]
    public bool SaveDocumentAsText { get; set; } = false;

    [JsonInclude]
    public int CurrentThemeIndex { get; set; } = 0;

    [JsonInclude]
    public string CurrentThemeName
    {
        get => CurrentThemeIndex switch
        {
            0 => "Visual Studio 2003",
            1 => "Visual Studio 2005",
            2 => "Visual Studio 2012 Light",
            3 => "Visual Studio 2012 Blue",
            4 => "Visual Studio 2012 Dark",
            5 => "Visual Studio 2013 Light",
            6 => "Visual Studio 2013 Blue",
            7 => "Visual Studio 2013 Dark",
            8 => "Visual Studio 2015 Light",
            9 => "Visual Studio 2015 Blue",
            10 => "Visual Studio 2015 Dark",
            _ => "Visual Studio 2003",
        };
    }

    [JsonInclude]
    public bool AutoSaveBookmarks { get; set; } = true;

    public void Serialize()
    {
        string jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(SettingsFileName, jsonString);
    }

    public static AppSettings Deserialize()
    {
        if (!File.Exists(SettingsFileName))
        {
            return new AppSettings();
        }

        string jsonText = File.ReadAllText(SettingsFileName);
        return JsonSerializer.Deserialize<AppSettings>(jsonText) ?? new AppSettings();
    }

    public static AppSettings Current { get; set; } = Deserialize();
}