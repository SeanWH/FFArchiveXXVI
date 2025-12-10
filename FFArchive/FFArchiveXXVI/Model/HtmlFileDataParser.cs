namespace FFArchiveXXVI.Model;

using System.Text.RegularExpressions;

using HtmlAgilityPack;

public static partial class HtmlFileDataParser
{
    public static HtmlFileData ParseHtml(string documentTitle, string htmlContent)
    {
        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(htmlContent);

        return new HtmlFileData
        {
            FileName = GetFileName(document),
            StoryTitle = GetStoryTitle(document),
            PageTitle = documentTitle,
            PageText = htmlContent,
            ChapterIndex = GetChapterIndex(document),
            SaveFolderName = GetSaveFolderName(GetStoryTitle(document)),
        };
    }

    private static string GetStoryTitle(HtmlDocument document)
    {
        var titleNode = document.DocumentNode.SelectSingleNode("//head/title").InnerText;
        titleNode = titleNode.Substring(0, titleNode.IndexOf("Chapter")).Trim();
        return titleNode;
    }

    private static string GetChapterIndex(HtmlDocument document)
    {
        var titleNode = document.DocumentNode.SelectSingleNode("//head/title").InnerText;
        string[] parts = titleNode.Split(", a");
        string chapterPart = parts[0].Substring(parts[0].LastIndexOf("Chapter")).Trim();
        string chapterIndex = ChapterIndexRegex().Match(chapterPart).Value;
        return chapterIndex.PadLeft(4, '0');
    }

    private static string GetSaveFolderName(string storyName)
    {
        return storyName.Replace(' ', '_');
    }

    private static string GetFileName(HtmlDocument document)
    {
        return $"Chapter_{GetChapterIndex(document)}.html";
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex ChapterIndexRegex();
}