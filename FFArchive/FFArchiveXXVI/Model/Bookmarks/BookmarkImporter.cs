namespace FFArchiveXXVI.Model.Bookmarks;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using htmlAgilityPack = HtmlAgilityPack;

public static class BookmarkImporter
{
    public static List<Bookmark> ImportBookmarks(string siteName)
    {
        string filePath = GetFilePathFromUser();
        List<Bookmark> bookmarks = [];
        if (string.IsNullOrEmpty(filePath))
        {
            return bookmarks;
        }
        htmlAgilityPack.HtmlDocument htmlDoc = new();
        htmlDoc.Load(filePath);
        var linkNodes = htmlDoc.DocumentNode.SelectNodes("//a");
        if (linkNodes != null)
        {
            foreach (var linkNode in linkNodes)
            {
                string url = linkNode.GetAttributeValue("HREF", string.Empty).Trim();
                if (!string.IsNullOrEmpty(url) && url.Contains(siteName, StringComparison.CurrentCultureIgnoreCase))
                {
                    string rawTitle = linkNode.InnerText.Trim();
                    string title = url.Contains("community", StringComparison.CurrentCultureIgnoreCase) ? rawTitle[..rawTitle.IndexOf('|')] : CleanBookmarkTitle(rawTitle);
                    bookmarks.Add(new Bookmark(title, url));
                }
            }
        }
        return bookmarks;
    }

    private static string CleanBookmarkTitle(string title)
    {
        string cleanTitle = title;

        if (string.IsNullOrWhiteSpace(title))
        {
            return "Untitled";
        }

        if (title.Contains("FanFiction.Net", StringComparison.CurrentCultureIgnoreCase))
        {
            cleanTitle = cleanTitle.Replace("FanFiction.Net", "");
        }

        if (title.Contains("C2", StringComparison.CurrentCultureIgnoreCase))
        {
            cleanTitle = cleanTitle.Replace("C2", "");
        }

        if (title.Contains(':') || title.Contains('|'))
        {
            cleanTitle = cleanTitle.Replace(":", "");
            cleanTitle = cleanTitle.Replace("|", "");
        }

        if (title.Contains("Profile", StringComparison.CurrentCultureIgnoreCase))
        {
            cleanTitle = cleanTitle.Replace("Profile", "");
        }
        return cleanTitle.Trim();
    }

    private static string GetFilePathFromUser()
    {
        using OpenFileDialog openFileDialog = new()
        {
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Filter = "Bookmark Files (*.htm, *.html)|*.htm;*.html",
            RestoreDirectory = true,
            Title = "Import Bookmark File"
        };
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            return openFileDialog.FileName;
        }
        else
        {
            return string.Empty;
        }
    }
}