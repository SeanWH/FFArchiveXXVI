using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace FFArchive.Settings
{
    internal class XmlConfig
    {
        public enum IoState { Read, Write }

        public AppSettings Settings { get; set; } = new AppSettings();

        public XmlConfig(IoState rw)
        {
            if (rw == IoState.Read)
            {
                ReadConfig();
            }
        }

        public void WriteConfig()
        {
            XmlTextWriter xw = new XmlTextWriter("config.xml", null)
            {
                Formatting = Formatting.Indented,
                Indentation = 2
            };
            xw.WriteStartDocument();

            xw.WriteStartElement("settings");

            xw.WriteStartElement("save_options");
            xw.WriteStartElement("savePath");
            xw.WriteString(Settings.SavePath);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsHtml");
            xw.WriteValue(Settings.SaveDocumentAsHtml);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsText");
            xw.WriteValue(Settings.SaveDocumentAsText);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsRtf");
            xw.WriteValue(Settings.SaveDocumentAsRtf);
            xw.WriteEndElement();

            xw.WriteStartElement("compress");
            xw.WriteValue(Settings.UseCompression);
            xw.WriteEndElement();

            xw.WriteStartElement("saveBookmarks");
            xw.WriteValue(Settings.AutoSaveBookmarksAfterImport);
            xw.WriteEndElement();
            xw.WriteEndElement();

            xw.WriteStartElement("display_options");
            xw.WriteStartElement("displayHtml");
            xw.WriteValue(Settings.DisplayHtml);
            xw.WriteEndElement();
            xw.WriteStartElement("displayText");
            xw.WriteValue(Settings.DisplayText);
            xw.WriteEndElement();
            xw.WriteStartElement("displayRtf");
            xw.WriteValue(Settings.DisplayRtf);
            xw.WriteEndElement();
            xw.WriteEndElement();

            xw.WriteStartElement("web_site_filtering");
            xw.WriteStartElement("filtercount");
            xw.WriteValue(Settings.FilterCount);
            xw.WriteEndElement();

            int index = 0;
            foreach (string filter in Settings.Filters)
            {
                string id = $"filteritem_{index.ToString()}";
                string text = filter ?? string.Empty;
                xw.WriteStartElement(id);
                xw.WriteString(text);
                xw.WriteEndElement();
                index++;
            }

            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Flush();
            xw.Close();
        }

        private void ReadConfig()
        {
            if (File.Exists("config.xml"))
            {
                using (XmlReader xr = XmlReader.Create("config.xml"))
                {
                    xr.Read();
                    xr.ReadStartElement("settings");
                    xr.ReadStartElement("save_options");
                    xr.ReadStartElement("savePath");
                    Settings.SavePath = xr.ReadString();
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsHtml");
                    Settings.SaveDocumentAsHtml = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsText");
                    Settings.SaveDocumentAsText = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsRtf");
                    Settings.SaveDocumentAsRtf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("compress");
                    Settings.UseCompression = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveBookmarks");
                    Settings.AutoSaveBookmarksAfterImport = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadEndElement();

                    xr.ReadStartElement("display_options");
                    xr.ReadStartElement("displayHtml");
                    Settings.DisplayHtml = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("displayText");
                    Settings.DisplayText = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("displayRtf");
                    Settings.DisplayRtf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadEndElement();

                    xr.ReadStartElement("web_site_filtering");
                    xr.ReadStartElement("filtercount");
                    int count = (int)xr.ReadContentAs(typeof(int), null);
                    xr.ReadEndElement();

                    List<string> sites = new List<string>();
                    int cnt = 0;
                    while (cnt < count)
                    {
                        string id = "filteritem_" + Convert.ToString(cnt);
                        xr.ReadStartElement(id);
                        sites.Add(xr.ReadString());
                        xr.ReadEndElement();
                        cnt++;
                    }
                    Settings.Filters = sites;
                    xr.ReadEndElement();
                }
            }
            else
            {
                WriteConfig();
                ReadConfig();
            }
        }
    }
}