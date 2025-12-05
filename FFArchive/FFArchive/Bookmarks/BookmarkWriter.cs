using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace FFArchive.Bookmarks
{
    class BookmarkWriter
    {
        private StringCollection filters = new StringCollection();
        private OrderedDictionary _sites = new OrderedDictionary();
        private string path;

        private StatusStrip sb = new StatusStrip();

        public BookmarkWriter(OrderedDictionary bc, StringCollection filterlist, ref StatusStrip sb1)
        {
            _sites = bc;
            filters = filterlist;
            sb = sb1;
            path = Application.StartupPath + Path.DirectorySeparatorChar + "bookmarks.xml";
        }

        private string filterTitle(string title)
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

        public void writeBookmarks()
        {
            using (XmlTextWriter xw = new XmlTextWriter(path, null))
            {
                ToolStripLabel tsl = new ToolStripLabel();
                ToolStripProgressBar tspb = new ToolStripProgressBar();

                tsl.Text = "Writing Bookmarks To File:";
                tsl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                tsl.AutoSize = true;
                sb.Items.Add(tsl);

                Application.DoEvents();

                xw.Formatting = Formatting.Indented;
                xw.Indentation = 2;

                xw.WriteStartDocument();
                xw.WriteStartElement("bookmarks");

                int cnt = 0;
                while (cnt < filters.Count)
                {
                    string _filter = filters[cnt];
                    OrderedDictionary _site = (OrderedDictionary)_sites[_filter];
                    BookmarkCollection _stories = (BookmarkCollection)_site["stories"];
                    BookmarkCollection _authors = (BookmarkCollection)_site["authors"];
                    BookmarkCollection _c2groups = (BookmarkCollection)_site["c2groups"];

                    xw.WriteStartElement("site");
                    xw.WriteAttributeString("name", _filter);
                    tspb.Maximum = 1;
                    tspb.Value = 0;
                    sb.Items.Add(tspb);

                    xw.WriteStartElement("stories");
                    xw.WriteAttributeString("count", Convert.ToString(_stories.Count));
                    foreach (Bookmark b in _stories)
                    {
                        xw.WriteStartElement("bookmark");
                        xw.WriteAttributeString("title", b.Title);
                        xw.WriteString(b.Address);
                        xw.WriteEndElement();
                        tspb.Maximum++;
                        tspb.Value++;
                    }
                    xw.WriteEndElement();
                    xw.WriteStartElement("authors");
                    xw.WriteAttributeString("count", Convert.ToString(_authors.Count));
                    foreach (Bookmark b in _authors)
                    {
                        xw.WriteStartElement("bookmark");
                        xw.WriteAttributeString("title", b.Title);
                        xw.WriteString(b.Address);
                        xw.WriteEndElement();
                        tspb.Maximum++;
                        tspb.Value++;
                    }
                    xw.WriteEndElement();
                    xw.WriteStartElement("c2groups");
                    xw.WriteAttributeString("count", Convert.ToString(_c2groups.Count));
                    foreach (Bookmark b in _c2groups)
                    {
                        xw.WriteStartElement("bookmark");
                        xw.WriteAttributeString("title", b.Title);
                        xw.WriteString(b.Address);
                        xw.WriteEndElement();
                        tspb.Maximum++;
                        tspb.Value++;
                    }
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    cnt++;
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Flush();
                xw.Close();
                sb.Items.Clear();
            }
        }
    }
}
