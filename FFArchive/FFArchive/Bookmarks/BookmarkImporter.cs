using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.Bookmarks
{
    /// <summary>
    ///     FFArchive.Bookmarks.BookmarkImporter class.
    ///     Imports FanFiction related bookmarks from an HTML file.
    /// </summary>
    public class BookmarkImporter
    {
        private StringCollection _filters = new StringCollection();
        private StatusStrip _ss;
        private OrderedDictionary _sites = new OrderedDictionary();
        private bool _done = false;
        private OrderedDictionary _sitecounts = new OrderedDictionary();
        private OrderedDictionary _oldsites = new OrderedDictionary();

        public BookmarkImporter(StringCollection filters, OrderedDictionary bkmklist, ref StatusStrip ss)
        {
            _filters = filters;
            _ss = ss;
            _oldsites = bkmklist;
            import();
        }

        public OrderedDictionary Sites
        {
            get { return _sites; }
        }

        public OrderedDictionary SiteCounts
        {
            get { return _sitecounts; }
        }

        private void import()
        {
            BookmarkCollection bc = new BookmarkCollection();
            _ss.Items.Clear();
            ToolStripStatusLabel tsl = new ToolStripStatusLabel("Importing Bookmarks:");
            ToolStripProgressBar tspb = new ToolStripProgressBar();
            tspb.Maximum = 1;
            tspb.Value = 0;
            _ss.Items.Add(tsl);
            _ss.Items.Add(tspb);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "HTML Files (*.htm;*.html)|*.htm'*.html|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                WebRequest request = WebRequest.Create(ofd.FileName);
                request.Credentials = CredentialCache.DefaultCredentials;
                FileWebResponse response = (FileWebResponse)request.GetResponse();
                WebBrowser wb = new WebBrowser();
                wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
                wb.DocumentStream = response.GetResponseStream();
                while (!_done) 
                {
                    Application.DoEvents(); 
                }
                HtmlDocument doc = wb.Document;
                wb.Dispose();
                HtmlElementCollection elems = doc.GetElementsByTagName("a");
                foreach (HtmlElement elem in elems)
                {
                    string address = elem.GetAttribute("href");
                    for (int i = 0; i < _filters.Count; i++)
                    {
                        try
                        {
                            string site = _filters[i];
                            if (address.Contains(site))
                            {
                                string title = filterTitle(elem.InnerText);
                                Bookmark b = new Bookmark(title, address, site);
                                bc.Add(b);
                                break;
                            }
                        }
                        catch (InvalidOperationException)
                        {
                        }
                    }
                    tspb.Maximum++;
                    tspb.Value++;
                }
                process(bc);
            }
        }

        private void process(BookmarkCollection bc)
        {
            for (int i = 0; i < _filters.Count; i++)
            {
                BookmarkCollection _stories = new BookmarkCollection();
                BookmarkCollection _authors = new BookmarkCollection();
                BookmarkCollection _c2groups = new BookmarkCollection();
                OrderedDictionary _site = new OrderedDictionary();

                SiteInfo _si = new SiteInfo();
                _si.Name = _filters[i];

                if (!(_oldsites == null))
                {
                    OrderedDictionary _oldsite = (OrderedDictionary)_oldsites[_filters[i]];
                    _stories = (BookmarkCollection)_oldsite["stories"];
                    _authors = (BookmarkCollection)_oldsite["authors"];
                    _c2groups = (BookmarkCollection)_oldsite["c2groups"];
                    _si.AuthorCount = _authors.Count;
                    _si.C2Count = _c2groups.Count;
                    _si.StoryCount = _stories.Count;
                }

                foreach (Bookmark b in bc)
                {
                    if (b.Site.Equals(_filters[i], StringComparison.OrdinalIgnoreCase))
                    {
                        switch (b.LinkType)
                        {
                            case LinkTarget.Author:
                                _si.AuthorCount++;
                                _authors.Add(b);
                                break;
                            case LinkTarget.C2Group:
                                _si.C2Count++;
                                _c2groups.Add(b);
                                break;
                            case LinkTarget.Story:
                                _si.StoryCount++;
                                _stories.Add(b);
                                break;
                        }
                    }
                }
                _site.Add("authors", _authors);
                _site.Add("c2groups", _c2groups);
                _site.Add("stories", _stories);
                _sites.Add(_filters[i], _site);
                _sitecounts.Add(_filters[i], _si);
            }
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _done = true;
        }

        private string filterTitle(string title)
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
