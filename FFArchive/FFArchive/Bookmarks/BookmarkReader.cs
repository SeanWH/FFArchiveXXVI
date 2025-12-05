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
    class BookmarkReader
    {
        private OrderedDictionary _sitecounts = new OrderedDictionary();

        public OrderedDictionary readBookmarks(StringCollection filters)
        {
            OrderedDictionary _sites = new OrderedDictionary();
            string path = Application.StartupPath + Path.DirectorySeparatorChar + "bookmarks.xml";
            XmlDocument _doc = new XmlDocument();
            _doc.Load(path);
            XmlNodeList xnl = _doc.GetElementsByTagName("site");
            SiteInfo si = new SiteInfo();
            foreach (XmlNode node in xnl)
            {
                OrderedDictionary _site = new OrderedDictionary();
                XmlAttributeCollection xac = node.Attributes;
                BookmarkCollection stories = new BookmarkCollection();
                BookmarkCollection authors = new BookmarkCollection();
                BookmarkCollection c2groups = new BookmarkCollection();
                XmlNodeList nodes = node.ChildNodes;
                XmlNodeList _stories = nodes[0].ChildNodes;
                XmlNodeList _authors = nodes[1].ChildNodes;
                XmlNodeList _c2groups = nodes[2].ChildNodes;
                XmlAttributeCollection a;
                XmlAttribute txa;
                string t;
                string add;
                XmlAttribute xa = xac["name"];
                string site = xa.Value;
                si.Name = site;
                si.AuthorCount = 0;
                si.C2Count = 0;
                si.StoryCount = 0;

                foreach (XmlNode story in _stories)
                {
                    a = story.Attributes;
                    txa = a["title"];
                    t = txa.Value;
                    add = story.InnerText;
                    Bookmark b = new Bookmark(t, add, site);
                    stories.Add(b);
                    si.StoryCount++;
                }
                _site.Add("stories", stories);

                foreach (XmlNode author in _authors)
                {
                    a = author.Attributes;
                    txa = a["title"];
                    t = txa.Value;
                    add = author.InnerText;
                    Bookmark b = new Bookmark(t, add, site);
                    authors.Add(b);
                    si.AuthorCount++;
                }
                _site.Add("authors", authors);

                foreach (XmlNode c2 in c2groups)
                {
                    a = c2.Attributes;
                    txa = a["title"];
                    t = txa.Value;
                    add = c2.InnerText;
                    Bookmark b = new Bookmark(t, add, site);
                    c2groups.Add(b);
                    si.C2Count++;
                }
                _site.Add("c2groups", c2groups);
                _sites.Add(site, _site);
                _sitecounts.Add(site, si);
            }
            return _sites;
        }

        public OrderedDictionary SiteCounts
        {
            get { return _sitecounts; }
        }
    }
}
