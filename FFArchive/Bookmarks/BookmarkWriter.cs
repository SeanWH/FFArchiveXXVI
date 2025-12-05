using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FFArchive.Bookmarks
{
    internal class BookmarkWriter
    {
        private readonly List<string> _filters;
        private readonly OrderedDictionary _sites;
        private readonly string _path;

        private readonly StatusStrip _statusStrip;
        private ToolStripProgressBar _progressBar;
        private ToolStripLabel _toolStripLabel;

        public BookmarkWriter(OrderedDictionary sites, List<string> filterList, ref StatusStrip statusStrip)
        {
            _sites = sites;
            _filters = filterList;
            _statusStrip = statusStrip;
            _path = Application.StartupPath + Path.DirectorySeparatorChar + "bookmarks.xml";
        }

        private string FilterTitle(string title)
        {
            string tmp = title.ToUpper();
            if (tmp.StartsWith("FANFICTION.NET"))
            {
                int pos = tmp.IndexOf(":");
                if (pos != -1)
                {
                    title = title.Substring(pos + 1).Trim();
                }
                else
                {
                    pos = tmp.IndexOf("FANFICTION.NET");
                    pos = pos + 15;
                    title = title.Substring(pos).Trim();
                }
            }
            return title;
        }

        private void WriteStoryBookmarks(OrderedDictionary site, XmlTextWriter xmlTextWriter)
        {
            BookmarkList stories = (BookmarkList)site["stories"];
            xmlTextWriter.WriteStartElement("stories");
            xmlTextWriter.WriteAttributeString("count", Convert.ToString(stories.Count));
            foreach (Bookmark b in stories)
            {
                xmlTextWriter.WriteStartElement("bookmark");
                xmlTextWriter.WriteAttributeString("title", b.Title);
                xmlTextWriter.WriteString(b.Address);
                xmlTextWriter.WriteEndElement();
                _progressBar.Maximum++;
                _progressBar.Value++;
                Application.DoEvents();
            }
            xmlTextWriter.WriteEndElement();
        }

        private void WriteAuthorBookmarks(OrderedDictionary site, XmlTextWriter xmlTextWriter)
        {
            BookmarkList authors = (BookmarkList)site["authors"];
            xmlTextWriter.WriteStartElement("authors");
            xmlTextWriter.WriteAttributeString("count", Convert.ToString(authors.Count));
            foreach (Bookmark b in authors)
            {
                xmlTextWriter.WriteStartElement("bookmark");
                xmlTextWriter.WriteAttributeString("author", b.Title);
                xmlTextWriter.WriteString(b.Address);
                xmlTextWriter.WriteEndElement();
                _progressBar.Maximum++;
                _progressBar.Value++;
                Application.DoEvents();
            }
            xmlTextWriter.WriteEndElement();
        }

        private void WriteC2Bookmarks(OrderedDictionary site, XmlTextWriter xmlTextWriter)
        {
            BookmarkList c2Groups = (BookmarkList)site["c2groups"];
            xmlTextWriter.WriteStartElement("c2groups");
            xmlTextWriter.WriteAttributeString("count", Convert.ToString(c2Groups.Count));
            foreach (Bookmark b in c2Groups)
            {
                xmlTextWriter.WriteStartElement("bookmark");
                xmlTextWriter.WriteAttributeString("c2group", b.Title);
                xmlTextWriter.WriteString(b.Address);
                xmlTextWriter.WriteEndElement();
                _progressBar.Maximum++;
                _progressBar.Value++;
                Application.DoEvents();
            }
            xmlTextWriter.WriteEndElement();
        }

        public void WriteBookmarks()
        {
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(_path, null))
            {
                _toolStripLabel = new ToolStripLabel("Writing Bookmarks To File:")
                {
                    TextAlign = ContentAlignment.MiddleRight,
                    AutoSize = true
                };
                _statusStrip.Items.Add(_toolStripLabel);

                _progressBar = new ToolStripProgressBar();

                Application.DoEvents();

                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 2;

                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("bookmarks");

                foreach (string filter in _filters)
                {
                    OrderedDictionary site = (OrderedDictionary)_sites[filter];
                    xmlTextWriter.WriteStartElement("site");
                    xmlTextWriter.WriteAttributeString("name", filter);
                    _progressBar.Maximum = 1;
                    _progressBar.Value = 0;
                    _statusStrip.Items.Add(_progressBar);

                    WriteStoryBookmarks(site, xmlTextWriter);
                    WriteAuthorBookmarks(site, xmlTextWriter);
                    WriteC2Bookmarks(site, xmlTextWriter);

                    xmlTextWriter.WriteEndElement();
                }

                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
                _statusStrip.Items.Clear();
            }
        }
    }
}