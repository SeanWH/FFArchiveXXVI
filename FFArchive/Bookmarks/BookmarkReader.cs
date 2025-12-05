using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FFArchive.Bookmarks
{
    internal class BookmarkReader
    {
        private readonly OrderedDictionary _siteCounts = new OrderedDictionary();
        private readonly BookmarkList _stories = new BookmarkList();
        private readonly BookmarkList _authors = new BookmarkList();
        private readonly BookmarkList _c2Groups = new BookmarkList();
        private SiteInfo _siteInfo;

        private void GetStoryBookmarks(string site, XmlNodeList nodes)
        {
            XmlNodeList storyNodes = nodes[0].ChildNodes;
            foreach (XmlNode story in storyNodes)
            {
                XmlAttributeCollection attributes = story.Attributes;
                if (attributes != null)
                {
                    XmlAttribute titleAttribute = attributes["title"];
                    string value = titleAttribute.Value;
                    string address = story.InnerText;
                    _stories.Add(new Bookmark(value, address, site));
                    _siteInfo.StoryCount++;
                }
            }
        }

        private void GetAuthorBookmarks(string site, XmlNodeList nodes)
        {
            XmlNodeList authorNodes = nodes[1].ChildNodes;
            foreach (XmlNode author in authorNodes)
            {
                XmlAttributeCollection attributes = author.Attributes;
                if (attributes != null)
                {
                    XmlAttribute authorAttribute = attributes["author"];
                    string value = authorAttribute.Value;
                    string address = author.InnerText;
                    _authors.Add(new Bookmark(value, address, site));
                    _siteInfo.AuthorCount++;
                }
            }
        }

        private void GetC2GroupBookmarks(string site, XmlNodeList nodes)
        {
            XmlNodeList c2Nodes = nodes[2].ChildNodes;
            foreach (XmlNode group in c2Nodes)
            {
                XmlAttributeCollection attributes = group.Attributes;
                if (attributes != null)
                {
                    XmlAttribute c2Attribute = attributes["c2group"];
                    string value = c2Attribute.Value;
                    string address = group.InnerText;
                    _c2Groups.Add(new Bookmark(value, address, site));
                    _siteInfo.C2Count++;
                }
            }
        }

        public OrderedDictionary ReadBookmarkFile()
        {
            OrderedDictionary sites = new OrderedDictionary();
            string path = Application.StartupPath + Path.DirectorySeparatorChar + "bookmarks.xml";

            if (File.Exists(path))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("site");

                foreach (XmlNode node in xmlNodeList)
                {
                    if (node != null)
                    {
                        OrderedDictionary siteDictionary = new OrderedDictionary();

                        XmlNodeList nodes = node.ChildNodes;

                        string site = ReadSiteInfo(node);

                        if (string.IsNullOrWhiteSpace(site) == false)
                        {
                            GetStoryBookmarks(site, nodes);
                            siteDictionary.Add("stories", _stories);
                            GetAuthorBookmarks(site, nodes);
                            siteDictionary.Add("authors", _authors);
                            GetC2GroupBookmarks(site, nodes);
                            siteDictionary.Add("c2groups", _c2Groups);
                            sites.Add(site, siteDictionary);
                            _siteCounts.Add(site, _siteInfo);
                        }
                    }
                }
            }
            return sites;
        }

        private string ReadSiteInfo(XmlNode node)
        {
            if (node != null)
            {
                if (node.Attributes != null)
                {
                    string site = node.Attributes["name"].Value;
                    _siteInfo = new SiteInfo()
                    {
                        AuthorCount = 0,
                        C2Count = 0,
                        Name = site,
                        StoryCount = 0
                    };
                    return site;
                }
                else
                {
                    throw new ArgumentNullException(nameof(node), "SiteInfo node cannot be null.");
                }
            }

            return string.Empty;
        }

        public OrderedDictionary SiteCounts => _siteCounts;
    }
}