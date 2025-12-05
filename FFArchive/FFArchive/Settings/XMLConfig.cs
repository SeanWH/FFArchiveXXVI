using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace FFArchive.Settings
{
    class XMLConfig
    {
        private AppSettings settings = new AppSettings();
        
        public enum ioState { Read, Write };

        public AppSettings Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        public XMLConfig(ioState rw)
        {
            if (rw == ioState.Read)
            {
                readConfig();
            }
        }
        
        public void writeConfig()
        {
            XmlTextWriter xw = new XmlTextWriter("config.xml", null);
            xw.Formatting = Formatting.Indented;
            xw.Indentation = 2;
            xw.WriteStartDocument();
            
            xw.WriteStartElement("settings");

            xw.WriteStartElement("save_options");
            xw.WriteStartElement("savePath");
            xw.WriteString(settings.SavePath);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsHtml");
            xw.WriteValue(settings.SaveDocumentAsHtml);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsText");
            xw.WriteValue(settings.SaveDocumentAsText);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsRtf");
            xw.WriteValue(settings.SaveDocumentAsRtf);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsPdf");
            xw.WriteValue(settings.SaveDocumentAsPdf);
            xw.WriteEndElement();

            xw.WriteStartElement("saveAsFfx");
            xw.WriteValue(settings.SaveDocumentAsFfx);
            xw.WriteEndElement();

            xw.WriteStartElement("compress");
            xw.WriteValue(settings.UseCompression);
            xw.WriteEndElement();

            xw.WriteStartElement("pdfFormat");
            xw.WriteValue(Convert.ToString(settings.CreatePdfFrom));
            xw.WriteEndElement();

            xw.WriteStartElement("saveBookmarks");
            xw.WriteValue(settings.AutoSaveBookmarksAfterImport);
            xw.WriteEndElement();
            xw.WriteEndElement();

            xw.WriteStartElement("display_options");
            xw.WriteStartElement("displayHtml");
            xw.WriteValue(settings.DisplayHtml);
            xw.WriteEndElement();
            xw.WriteStartElement("displayText");
            xw.WriteValue(settings.DisplayText);
            xw.WriteEndElement();
            xw.WriteStartElement("displayRtf");
            xw.WriteValue(settings.DisplayRtf);
            xw.WriteEndElement();
            xw.WriteStartElement("displayPdf");
            xw.WriteValue(settings.DisplayPdf);
            xw.WriteEndElement();
            xw.WriteStartElement("displayFfx");
            xw.WriteValue(settings.DisplayFfx);
            xw.WriteEndElement();
            xw.WriteEndElement();
            

            xw.WriteStartElement("web_site_filtering");
            xw.WriteStartElement("filtercount");
            xw.WriteValue(settings.FilterCount);
            xw.WriteEndElement();

            StringEnumerator ie = settings.Filters.GetEnumerator();
            int cnt = 0;
            while (cnt < settings.FilterCount)
            {
                ie.MoveNext();
                string id = "filteritem_" + Convert.ToString(cnt);
                string text = (string)ie.Current;
                xw.WriteStartElement(id);
                xw.WriteString(text);
                xw.WriteEndElement();
                cnt++;
            }

            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Flush();
            xw.Close();
        }

        

        private void readConfig()
        {
            if(File.Exists("config.xml")) 
            {
                using (XmlReader xr = XmlReader.Create("config.xml"))
                {
                    xr.Read();
                    xr.ReadStartElement("settings");
                    xr.ReadStartElement("save_options");
                    xr.ReadStartElement("savePath");
                    settings.SavePath = xr.ReadString();
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsHtml");
                    settings.SaveDocumentAsHtml = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsText");
                    settings.SaveDocumentAsText = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsRtf");
                    settings.SaveDocumentAsRtf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsPdf");
                    settings.SaveDocumentAsPdf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveAsFfx");
                    settings.SaveDocumentAsPdf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("compress");
                    settings.UseCompression = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("pdfFormat");
                    string tmp = xr.ReadString();
                    switch (tmp)
                    {
                        case "NONE":
                            settings.CreatePdfFrom = PdfGenFrom.NONE;
                            break;
                        case "HTML":
                            settings.CreatePdfFrom = PdfGenFrom.HTML;
                            break;
                        case "RTF":
                            settings.CreatePdfFrom = PdfGenFrom.RTF;
                            break;
                        case "FFX":
                            settings.CreatePdfFrom = PdfGenFrom.FFX;
                            break;
                        case "TEXT":
                            settings.CreatePdfFrom = PdfGenFrom.TEXT;
                            break;
                    }
                    xr.ReadEndElement();
                    xr.ReadStartElement("saveBookmarks");
                    settings.AutoSaveBookmarksAfterImport = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadEndElement();

                    xr.ReadStartElement("display_options");
                    xr.ReadStartElement("displayHtml");
                    settings.DisplayHtml = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("displayText");
                    settings.DisplayText = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("displayRtf");
                    settings.DisplayRtf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("displayPdf");
                    settings.DisplayPdf = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadStartElement("displayFfx");
                    settings.DisplayFfx = (bool)xr.ReadContentAs(typeof(bool), null);
                    xr.ReadEndElement();
                    xr.ReadEndElement();

                    xr.ReadStartElement("web_site_filtering");
                    xr.ReadStartElement("filtercount");
                    int count = (int)xr.ReadContentAs(typeof(int), null);
                    xr.ReadEndElement();


                    StringCollection sites = new StringCollection();
                    int cnt = 0;
                    while (cnt < count)
                    {
                        string id = "filteritem_" + Convert.ToString(cnt);
                        xr.ReadStartElement(id);
                        sites.Add(xr.ReadString());
                        xr.ReadEndElement();
                        cnt++;
                    }
                    settings.Filters = sites;
                    xr.ReadEndElement();
                } 
            }
            else
            {
                writeConfig();
                readConfig();
            }
          }
        }
    }

