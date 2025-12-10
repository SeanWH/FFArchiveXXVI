namespace FFArchiveXXVI.Model;

/// <summary>
/// A data object that holds metadata about an HTML file.
/// </summary>
public class HtmlFileData
{
    public string FileName { get; set; } = string.Empty;
    public string StoryTitle { get; set; } = string.Empty;
    public string PageTitle { get; set; } = string.Empty;
    public string PageText { get; set; } = string.Empty;
    public string ChapterIndex { get; set; } = string.Empty;
    public string SaveFolderName { get; set; } = string.Empty;
}