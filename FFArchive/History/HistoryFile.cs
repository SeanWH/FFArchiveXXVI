using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FFArchive.History
{
    public static class HistoryFile
    {
        public static void WriteFile(HistoryByDateCollection historyByDateCollection, List<string> sites)
        {
            using (XmlTextWriter xw = new XmlTextWriter("history.xml", null))
            {
                xw.Formatting = Formatting.Indented;
                xw.Indentation = 2;

                xw.WriteStartDocument();
                xw.WriteStartElement("history");
                foreach (string site in sites)
                {
                    xw.WriteStartElement(site);

                    foreach (string date in historyByDateCollection.Keys)
                    {
                        foreach (HistoryEntry entry in historyByDateCollection[date])
                        {
                            if (entry.Site.Equals(site, StringComparison.OrdinalIgnoreCase))
                            {
                                xw.WriteStartElement("page");
                                xw.WriteAttributeString("date", entry.Date.ToString());
                                xw.WriteAttributeString("title", entry.Title);
                                xw.WriteAttributeString("hits", Convert.ToString(entry.Hits));
                                xw.WriteString(entry.Address);
                                xw.WriteEndElement();
                            }
                        }
                    }
                    xw.WriteEndElement();
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Flush();
                xw.Close();
            }
        }

        public static HistoryByDateCollection ReadFile(List<string> sites)
        {
            HistoryByDateCollection historyByDateCollection = new HistoryByDateCollection();
            XmlDocument doc = new XmlDocument();

            if (File.Exists("history.xml"))
            {
                doc.Load("history.xml");
            }
            else
            {
                return null;
            }
            foreach (string site in sites)
            {
                XmlNodeList xmlNodeList = doc.GetElementsByTagName(site);

                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    XmlNodeList nodes = xmlNode.ChildNodes;
                    foreach (XmlNode node in nodes)
                    {
                        HistoryEntry entry = GetEntryFromXml(site, node);

                        if (entry != null)
                        {
                            historyByDateCollection.Add(entry.Date, entry);
                        }
                    }
                }
            }

            return historyByDateCollection;
        }

        private static HistoryEntry GetEntryFromXml(string site, XmlNode node)
        {
            XmlAttributeCollection xmlAttributeCollection = node.Attributes;
            if (xmlAttributeCollection != null)
            {
                DateTime dateTime = DateTime.Parse(xmlAttributeCollection["date"].Value);
                string title = xmlAttributeCollection["title"].Value;
                string address = node.InnerText;
                return new HistoryEntry(dateTime, site, address, title);
            }

            return null;
        }
    }
}