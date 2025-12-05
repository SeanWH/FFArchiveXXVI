using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml;

namespace FFArchive.History
{
    public static class HistoryFile
    {
        public static void WriteFile(HistoryByDateCollection _history, StringCollection _sites)
        {
            using (XmlTextWriter xw = new XmlTextWriter("history.xml", null))
            {
                xw.Formatting = Formatting.Indented;
                xw.Indentation = 2;

                xw.WriteStartDocument();
                xw.WriteStartElement("history");
                for (int i = 0; i < _sites.Count; i++)
                {
                    xw.WriteStartElement(_sites[i]);
                    
                    foreach (string date in _history.Keys)
                    {
                        foreach (HistoryEntry entry in _history[date])
                        {
                            if (entry.Site.Equals(_sites[i], StringComparison.OrdinalIgnoreCase))
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

        public static HistoryByDateCollection ReadFile(StringCollection _sites)
        {
            HistoryByDateCollection _history = new HistoryByDateCollection();
            XmlDocument doc = new XmlDocument();
            XmlAttributeCollection xac;

            if (File.Exists("history.xml"))
            {
                doc.Load("history.xml");
            }
            else
            {
                return null;
            }
            for (int i = 0; i < _sites.Count; i++)
            {
                XmlNodeList xnl = doc.GetElementsByTagName(_sites[i]);

                foreach (XmlNode xn in xnl)
                {
                    XmlNodeList nodes = xn.ChildNodes;
                    foreach (XmlNode node in nodes)
                    {
                        xac = node.Attributes;
                        DateTime d = DateTime.Parse(xac["date"].Value);
                        string t = (string)xac["title"].Value;
                        string a = node.InnerText;
                        HistoryEntry he = new HistoryEntry(d, _sites[i], a, t);
                        _history.Add(he.Date, he);
                    }
                }
            }

            return _history;
        }
    }
}
