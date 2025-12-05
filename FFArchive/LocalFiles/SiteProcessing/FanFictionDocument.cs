using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.LocalFiles.SiteProcessing
{
    public class FanFictionDocument
    {
        private WebBrowser _webBrowserReference;
        private readonly string _site;

        public string Genre { get; set; }

        public string FileName { get; set; }

        public string Address { get; set; }

        public string PathToFile { get; set; }

        public HtmlDocument Story { get; set; }

        public string HtmlText { get; set; }

        public string PageAddress
        {
            get => Address;
            set => Address = value.StartsWith("http://") ? StripHttp(value) : value;
        }

        public string FilePath { private get; set; }
        public string DocumentText { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string WebSite { private get; set; }
        public string SavePath { private get; set; }

        public FanFictionDocument(ref WebBrowser webBrowserReference, string address, string savePath, string site)
        {
            Story = webBrowserReference.Document;
            PageAddress = address;
            SavePath = savePath;
            HtmlText = webBrowserReference.DocumentText;
            WebSite = site;

            _webBrowserReference = webBrowserReference;
            _site = site;

            ParseSiteData();

            FilePath = BuildPath();
        }

        public bool SaveMe { get; private set; } = true;

        private static string FilterFanFictionNetTitle(string fanFictionNetTitle)
        {
            int pos = fanFictionNetTitle.IndexOf(":", StringComparison.Ordinal);
            return fanFictionNetTitle.Substring(pos + 1).Trim();
        }

        private static string RemoveColon(string tmp)
        {
            string[] separator = { ":" };
            string[] clean = tmp.Split(separator, StringSplitOptions.None);
            StringBuilder result = new StringBuilder();

            int index = 0;
            while (index < clean.Length)
            {
                result.Append(clean[index]);
                result.Append("-");
            }

            if (result.ToString().EndsWith("-"))
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }

        private static string RemoveIllegalCharacters(string text)
        {
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
            char[] toClean = text.ToCharArray();
            StringBuilder cleaned = new StringBuilder();

            foreach (char c in toClean)
            {
                bool isInvalid = false;
                foreach (char ic in invalidFileNameChars)
                {
                    if (c.CompareTo(ic) == 0)
                    {
                        isInvalid = true;
                        break;
                    }
                }

                if (!isInvalid)
                {
                    cleaned.Append(c);
                }
            }

            return cleaned.ToString();
        }

        private void ParseSiteData()
        {
            HtmlElementCollection elementCollection = Story.GetElementsByTagName("a");
            string authorName = GetAuthor(elementCollection);
            string title = GetTitle();
            string genre = GetGenre(elementCollection);

            elementCollection = Story.GetElementsByTagName("option");
            string fileName = GetFileName(elementCollection);

            if (string.IsNullOrWhiteSpace(authorName))
            {
                SaveMe = false;
                return;
            }

            AuthorName = authorName;

            if (string.IsNullOrWhiteSpace(title))
            {
                SaveMe = false;
                return;
            }

            Title = title;
            Genre = genre;
            FileName = fileName;
        }

        private static string ParseAddress(string address)
        {
            string parsedAddress = address;
            int start = parsedAddress.LastIndexOf("/", StringComparison.Ordinal);
            parsedAddress = parsedAddress.Substring(0, start);
            start = parsedAddress.LastIndexOf("/", StringComparison.Ordinal);
            return parsedAddress.Substring(start + 1);
        }

        private string ProcessHtmlElementText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            string elementText = text;
            elementText = RemoveIllegalCharacters(elementText);

            if (string.IsNullOrWhiteSpace(elementText))
            {
                return string.Empty;
            }

            if (string.CompareOrdinal(elementText.ToLowerInvariant(), "menu") == 0)
            {
                return string.Empty;
            }

            elementText = elementText.Length <= 4 ? PadFileName(elementText) : elementText;
            int index = elementText.IndexOf('.');
            string fileName = PadFileName(elementText.Substring(0, index));
            elementText = elementText.Substring(index);

            StringBuilder final = new StringBuilder(fileName);
            final.Append(elementText);

            string value = final.ToString();
            value = value.Contains(":") ? RemoveColon(value) : value;
            return value;
        }

        private string GetFileName(HtmlElementCollection elementCollection)
        {
            string fileName = "";

            string address = ParseAddress(Address);

            foreach (HtmlElement element in elementCollection)
            {
                string value = element.GetAttribute("value");
                if (value.Equals(address))
                {
                    fileName = ProcessHtmlElementText(element.InnerText);
                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        continue;
                    }

                    break;
                }
            }

            return fileName;
        }

        private static string GetAuthor(HtmlElementCollection elementCollection)
        {
            foreach (HtmlElement elem in elementCollection)
            {
                string href = elem.GetAttribute("href");
                if (href.Contains("/u/"))
                {
                    return elem.InnerText;
                }
            }

            return string.Empty;
        }

        private static string GetGenre(HtmlElementCollection elementCollection)
        {
            foreach (HtmlElement elem in elementCollection)
            {
                string attribute = elem.GetAttribute("href");
                if (attribute.Contains("/cat/"))
                {
                    return elem.InnerText;
                }
            }

            return string.Empty;
        }

        private string GetTitle()
        {
            return FilterFanFictionNetTitle(_webBrowserReference.DocumentTitle);
        }

        public string PathToSavedFile => PathToFile;

        public void WriteText()
        {
            WriteTextFile();
        }

        public void WriteHtml()
        {
            WriteHtmlFile(ref _webBrowserReference);
        }

        private string BuildPath()
        {
            string path = Path.Combine(SavePath, WebSite, Genre, AuthorName, Title);
            Directory.CreateDirectory(path);
            return path;
        }

        private static string StripHttp(string address)
        {
            int p = address.IndexOf("http://", StringComparison.Ordinal);
            address = address.Substring(p + 7);
            return address;
        }

        private static string PadFileName(string filename)
        {
            StringBuilder tmp = new StringBuilder();
            if (filename.Length < 3)
            {
                int cnt = 3 - filename.Length;
                switch (cnt)
                {
                    case 1:
                        tmp.Append("0");
                        break;

                    case 2:
                        tmp.Append("00");
                        break;
                }

                tmp.Append(filename);
                return tmp.ToString();
            }

            return filename;
        }

        private List<string> GetStoryTextWithoutHtmlMarkup()
        {
            HtmlElementCollection htmlElementCollection = Story.GetElementsByTagName("p");
            List<string> text = new List<string>();

            foreach (HtmlElement element in htmlElementCollection)
            {
                text.Add(element.InnerText);
            }

            return text;
        }

        private void WriteTextFile()
        {
            PathToFile = Path.Combine(FilePath, FileName, ".txt");

            List<string> storyText = GetStoryTextWithoutHtmlMarkup();

            if (storyText != null && storyText.Any())
            {
                using (StreamWriter sw = new StreamWriter(PathToFile, false, Encoding.Unicode))
                {
                    foreach (string line in storyText)
                    {
                        if (string.IsNullOrWhiteSpace(line) == false)
                        {
                            sw.Write(line);
                            sw.Write(Environment.NewLine);
                            sw.Write(Environment.NewLine);
                        }
                    }
                    sw.Flush();
                }
            }
        }

        private void WriteHtmlFile(ref WebBrowser webBrowser)
        {
            if (string.IsNullOrWhiteSpace(FileName))
            {
                return;
            }

            PathToFile = Path.GetExtension(FileName).Contains("htm")
                ? Path.Combine(FilePath, FileName)
                : Path.Combine(FilePath, FileName, ".html");

            if (string.IsNullOrWhiteSpace(PathToFile))
            {
                return;
            }

            using (StreamWriter writer = File.CreateText(PathToFile))
            {
                writer.Write(webBrowser.DocumentText);
                writer.Flush();
            }
        }
    }
}