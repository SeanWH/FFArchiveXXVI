namespace FFArchiveXXVI.Model.Bookmarks;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using hap = HtmlAgilityPack;

public static class BookmarkImporter
{
    public static List<Bookmark> ImportBookmarks()
    {
        string filePath = GetFilePathFromUser();
        List<Bookmark> bookmarks = new();
        if (string.IsNullOrEmpty(filePath))
        {
            return bookmarks;
        }
        hap.HtmlDocument htmlDoc = new();
        htmlDoc.Load(filePath);
        var linkNodes = htmlDoc.DocumentNode.SelectNodes("//a");
        if (linkNodes != null)
        {
            foreach (var linkNode in linkNodes)
            {
                string title = CleanBookmarkTitle(linkNode.InnerText.Trim());
                string url = linkNode.GetAttributeValue("HREF", string.Empty).Trim();
                if (!string.IsNullOrEmpty(url))
                {
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

        if (title.Contains("FanFiction.Net"))
        {
            cleanTitle.Replace("FanFiction.Net", "");
        }

        if (title.Contains("C2"))
        {
            cleanTitle.Replace("C2", "");
        }

        if (title.Contains(":"))
        {
            cleanTitle.Replace(":", "");
        }

        if (title.Contains("Profile"))
        {
            cleanTitle.Replace("Profile", "");
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