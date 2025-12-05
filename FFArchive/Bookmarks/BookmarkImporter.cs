using HtmlAgilityPack;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace FFArchive.Bookmarks
{
    /// <summary>
    ///     FanFictionArchive.Bookmarks.BookmarkImporter class.
    ///     Imports FanFiction related bookmarks from an HTML file.
    /// </summary>
    public class BookmarkImporter
    {
        private readonly List<string> _filters;
        private readonly StatusStrip _statusStrip;
        private readonly OrderedDictionary _oldSites;
        private ToolStripStatusLabel _toolStripStatusLabel;
        private ToolStripProgressBar _toolStripProgressBar;

        public BookmarkImporter(List<string> filters, OrderedDictionary bookmarkDictionary, ref StatusStrip statusStrip)
        {
            _filters = filters;
            _statusStrip = statusStrip;
            _oldSites = bookmarkDictionary;
            Import();
        }

        public OrderedDictionary Sites { get; } = new OrderedDictionary();

        public OrderedDictionary SiteCounts { get; } = new OrderedDictionary();

        private void InitializeProgressUpdate()
        {
            _statusStrip.Items.Clear();
            _toolStripStatusLabel = new ToolStripStatusLabel("Importing Bookmarks:");
            _toolStripProgressBar = new ToolStripProgressBar
            {
                Maximum = 1,
                Value = 0
            };
            _statusStrip.Items.Add(_toolStripStatusLabel);
            _statusStrip.Items.Add(_toolStripProgressBar);
        }

        private static string GetFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "HTML Files (*.htm;*.html)|*.htm'*.html|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }

        private Bookmark GetBookmark(HtmlNode node)
        {
            string address = node.Attributes.AttributesWithName("href").First().Value;
            foreach (string filter in _filters)
            {
                string site = filter;
                if (address.Contains(site))
                {
                    string title = FilterTitle(node.InnerText);
                    return new Bookmark(title, address, site);
                }
            }

            return null;
        }

        private void Import()
        {
            BookmarkList bookmarkList = new BookmarkList();

            InitializeProgressUpdate();

            string fileName = GetFileName();

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(fileName);

                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a");
                foreach (HtmlNode node in nodes)
                {
                    Bookmark bookmark = GetBookmark(node);
                    if (bookmark != null)
                    {
                        bookmarkList.Add(bookmark);
                        _toolStripProgressBar.Maximum++;
                        _toolStripProgressBar.Value++;
                    }
                }

                if (bookmarkList.Any())
                {
                    Process(bookmarkList);
                }
            }
        }

        private void Process(BookmarkList bookmarkList)
        {
            foreach (string filter in _filters)
            {
                BookmarkList oldSiteStories = new BookmarkList();
                BookmarkList oldSiteAuthors = new BookmarkList();
                BookmarkList oldSiteC2Groups = new BookmarkList();
                OrderedDictionary site = new OrderedDictionary();

                SiteInfo siteInfo = new SiteInfo { Name = filter };

                if (_oldSites != null)
                {
                    OrderedDictionary oldSite = (OrderedDictionary)_oldSites[filter];
                    oldSiteStories = (BookmarkList)oldSite["stories"];
                    oldSiteAuthors = (BookmarkList)oldSite["authors"];
                    oldSiteC2Groups = (BookmarkList)oldSite["c2groups"];
                    siteInfo.AuthorCount = oldSiteAuthors.Count;
                    siteInfo.C2Count = oldSiteC2Groups.Count;
                    siteInfo.StoryCount = oldSiteStories.Count;
                }

                foreach (Bookmark bookmark in bookmarkList)
                {
                    if (bookmark.Site.Equals(filter, StringComparison.OrdinalIgnoreCase))
                    {
                        switch (bookmark.LinkType)
                        {
                            case LinkTarget.Author:
                                siteInfo.AuthorCount++;
                                oldSiteAuthors.Add(bookmark);
                                break;

                            case LinkTarget.C2Group:
                                siteInfo.C2Count++;
                                oldSiteC2Groups.Add(bookmark);
                                break;

                            case LinkTarget.Story:
                                siteInfo.StoryCount++;
                                oldSiteStories.Add(bookmark);
                                break;
                        }
                    }
                }
                site.Add("authors", oldSiteAuthors);
                site.Add("c2groups", oldSiteC2Groups);
                site.Add("stories", oldSiteStories);
                Sites.Add(filter, site);
                SiteCounts.Add(filter, siteInfo);
            }
        }

        private static string FilterTitle(string title)
        {
            if (title.StartsWith("fanfiction.net", StringComparison.OrdinalIgnoreCase))
            {
                int pos = title.IndexOf(":");
                if (pos != -1)
                {
                    title = title.Substring(pos + 1).Trim();
                }
                else
                {
                    pos = title.IndexOf("fanfiction.net", StringComparison.OrdinalIgnoreCase);
                    pos += 15;
                    title = title.Substring(pos).Trim();
                }
            }
            return title;
        }
    }
}