using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FFArchive.LocalFiles.SiteProcessing
{
    public class ffDocument : genericSite
    {
        private WebBrowser _wb;
        private string _site;
        private bool _saveme = true;

        public ffDocument(ref WebBrowser wb, string address, string savePath, string htmlText, string site)
        {
            this.Story = wb.Document;
            this.PageAddress = address;
            this.SavePath = savePath;
            this.HtmlText = htmlText;
            this.WebSite = site;

            _wb = wb;
            _site = site;
            
            parseSiteData();

            this.FilePath = this.buildPath();
        }

        public bool SaveMe
        {
            get { return _saveme; }
        }

        private string filterFFNTitle(string tmp)
        {
            int pos = tmp.IndexOf(":");
            string t = tmp.Substring(pos + 1);
            t.Trim();
            return t;
        }

        private string removeColon(string tmp)
        {
            string[] separator = new string[] { ":" };
            string[] clean = tmp.Split(separator, StringSplitOptions.None);
            StringBuilder result = new StringBuilder();

            int cnt = 0;
            while (cnt < clean.Length)
            {
                result.Append(clean[cnt]);
                result.Append("-");
            }

            if (result.ToString().EndsWith("-"))
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }

        private string removeIllegalCharacters(string text)
        {
            char[] illegal = Path.GetInvalidFileNameChars();
            char[] tmp = text.ToCharArray();
            StringBuilder cleaned = new StringBuilder();

            foreach (char c in tmp)
            {
                bool il = false;
                foreach (char ic in illegal)
                {
                    if (c.CompareTo(ic) == 0)
                    {
                        il = true;
                        break;
                    }
                }
                if (il == false)
                {
                    cleaned.Append(c);
                }
            }
            return cleaned.ToString();
        }

        protected override void parseSiteData()
        {
            getAuthor();
            if (String.IsNullOrEmpty(this.m_sAuthor))
            {
                _saveme = false;
                return;
            }
            getTitle();
            if (String.IsNullOrEmpty(this.m_sTitle))
            {
                _saveme = false;
                return;
            }
            getGenre();
            getFileName();
            
        }

        private void getFileName()
        {
            string name = "";
            int start;
            string address = m_sAddress;
            string temp;
            HtmlElementCollection elems;

            switch (_site)
            {
                case "fanfiction.net":
                    start = address.LastIndexOf("/");
                    address = address.Substring(0, start);
                    start = address.LastIndexOf("/");
                    address = address.Substring(start + 1);

                    elems = this.Story.GetElementsByTagName("option");
                    foreach (HtmlElement elem in elems)
                    {
                        string val = elem.GetAttribute("value");
                        string sel = elem.GetAttribute("selected");
                        if (val.Equals(address))
                        {
                            name = removeIllegalCharacters(elem.InnerText);
                            if (name.Equals("Menu")) continue;
                            if (name.Length <= 4)
                            {
                                name = padFileName(name);
                            }
                            int p = name.IndexOf(".");
                            string t = name.Substring(0, p);
                            name = name.Substring(p);
                            t = padFileName(t);
                            StringBuilder sb = new StringBuilder();
                            sb.Append(t);
                            sb.Append(name);
                            name = sb.ToString();
                            break;
                        }
                    }
                    if (name.Contains(":")) name = removeColon(name);
                    break;
                case "fanficauthors.net":
                    /*
                    start = address.LastIndexOf("/");
                    string fileName = removeIllegalCharacters(address.Substring(start + 1));
                    name = padFileName(fileName);
                     */
                    name = padFileName(Path.GetFileNameWithoutExtension(address));
                    break;
                case "adultfanfiction.net":
                    elems = this.Story.GetElementsByTagName("option");
                    foreach (HtmlElement elem in elems)
                    {
                        string sel = elem.GetAttribute("selected");
                        if (String.IsNullOrEmpty(sel) == false)
                        {
                            name = removeIllegalCharacters(elem.InnerText);
                            if (name.Length <= 4)
                            {
                                name = padFileName(name);
                                break;
                            }
                        }
                    }
                    break;
                case "harrypotterfanfiction.com":
                    break;
                case "portkey.org":
                    elems = this.Story.GetElementsByTagName("option");
                    StringBuilder n = new StringBuilder();
                    int pos = 1;
                    foreach (HtmlElement element in elems)
                    {
                        temp = element.GetAttribute("selected");
                        if (!String.IsNullOrEmpty(temp))
                        {
                            if (temp == "True")
                            {
                                if (pos < 10)
                                {
                                    n.Append("0" + Convert.ToString(pos) + "_");
                                }
                                else
                                {
                                    n.Append(Convert.ToString(pos) + "_");
                                }
                                n.Append(element.InnerText);
                                break;
                            }
                            
                        }
                        pos++;
                    }
                    name = removeIllegalCharacters(n.ToString());
                    break;
                case "schnoogle.com":
                    pos = address.IndexOf(this.AuthorName);
                    temp = address.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    temp = removeIllegalCharacters(temp);
                    name = padFileName(temp);
                    break;
                case "skyehawke.com":
                    elems = this.Story.GetElementsByTagName("option");
                    bool found = false;

                    foreach (HtmlElement elem in elems)
                    {
                        temp = elem.GetAttribute("selected");
                        if (String.IsNullOrEmpty(temp) == false)
                        {
                            if (temp == "True")
                            {
                                name = removeIllegalCharacters(elem.InnerText);
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        name = removeIllegalCharacters(elems[0].InnerText);
                    }
                    break;
                case "fictionalley.org":
                    pos = address.IndexOf(this.AuthorName);
                    temp = address.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    temp = removeIllegalCharacters(temp);
                    name = padFileName(temp);
                    break;
                case "astronomytower.org":
                    pos = address.IndexOf(this.AuthorName);
                    temp = address.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    temp = removeIllegalCharacters(temp);
                    name = padFileName(temp);
                    break;
                case "thedarkarts.org":
                    pos = address.IndexOf(this.AuthorName);
                    temp = address.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    temp = removeIllegalCharacters(temp);
                    name = padFileName(temp);
                    break;
                case "riddikulus.org":
                    pos = address.IndexOf(this.AuthorName);
                    temp = address.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    temp = removeIllegalCharacters(temp);
                    name = padFileName(temp);
                    break;
                case "ficwad.com":
                    break;
            }
            
            this.m_sFileName = name;
        }

        private void getAuthor()
        {
            int pos;
            HtmlElementCollection elems;
            string temp;
            switch (_site)
            {
                case "fanfiction.net":
                    elems = this.Story.GetElementsByTagName("a");
                    foreach (HtmlElement elem in elems)
                    {
                        string href = elem.GetAttribute("href");
                        if (href.Contains("/u/"))
                        {
                            this.m_sAuthor = elem.InnerText;
                            break;
                        }
                    }
                    break;
                case "fanficauthors.net":
                    pos = this.m_sAddress.IndexOf(".");
                    this.m_sAuthor = this.m_sAddress.Substring(0, pos);
                    break;
                case "adultfanfiction.net":
                    elems = this.Story.GetElementsByTagName("a");
                    foreach (HtmlElement elem in elems)
                    {
                        string href = elem.GetAttribute("href");
                        if (href.Contains("authors.php"))
                        {
                            this.m_sAuthor = elem.InnerText;
                            break;
                        }
                    }
                    break;
                case "harrypotterfanfiction.com":
                    break;
                case "portkey.org":
                    elems = this.Story.GetElementsByTagName("a");
                    bool found = false;
                    foreach (HtmlElement element in elems)
                    {
                        string tmp = element.GetAttribute("href");
                        if (!String.IsNullOrEmpty(tmp))
                        {
                            if (tmp.ToLower().Contains("/profile/"))
                            {
                                found = true;
                                this.m_sAuthor = element.InnerText;
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        this.m_sAuthor = null;
                    }
                    break;
                case "schnoogle.com":
                    pos = this.m_sAddress.IndexOf("author");
                    temp = this.m_sAddress.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    pos = temp.IndexOf("/");
                    this.m_sAuthor = temp.Substring(0, pos);
                    break;
                case "skyehawke.com":
                    elems = this.Story.GetElementsByTagName("a");
                    foreach (HtmlElement elem in elems)
                    {
                        string href = elem.GetAttribute("href");
                        if (href.Contains("authors.php?"))
                        {
                            this.m_sAuthor = elem.InnerText;
                            break;
                        }
                    }
                    break;
                case "fictionalley.org":
                    pos = this.m_sAddress.IndexOf("author");
                    temp = this.m_sAddress.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    pos = temp.IndexOf("/");
                    this.m_sAuthor = temp.Substring(0, pos);
                    break;
                case "astronomytower.org":
                    pos = this.m_sAddress.IndexOf("author");
                    temp = this.m_sAddress.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    pos = temp.IndexOf("/");
                    this.m_sAuthor = temp.Substring(0, pos);
                    break;
                case "thedarkarts.org":
                    pos = this.m_sAddress.IndexOf("author");
                    temp = this.m_sAddress.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    pos = temp.IndexOf("/");
                    this.m_sAuthor = temp.Substring(0, pos);
                    break;
                case "riddikulus.org":
                    pos = this.m_sAddress.IndexOf("author");
                    temp = this.m_sAddress.Substring(pos);
                    pos = temp.IndexOf("/");
                    temp = temp.Substring(pos + 1);
                    pos = temp.IndexOf("/");
                    this.m_sAuthor = temp.Substring(0, pos);
                    break;
                case "ficwad.com":
                    break;
            }
        }

        private void getGenre()
        {
            HtmlElementCollection elems;

            switch (_site)
            {
                case "fanfiction.net":
                    elems = this.Story.GetElementsByTagName("a");
                    bool found = false;

                    foreach (HtmlElement elem in elems)
                    {
                        if (!found)
                        {
                            try
                            {
                                string attrib = elem.GetAttribute("href");
                                if (attrib.Contains("/cat/"))
                                {
                                    found = true;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            this.m_sGenre = elem.InnerText;
                            break;
                        }
                    }
                    break;
                case "fanficauthors.net":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "adultfanfiction.net":
                    elems = this.Story.GetElementsByTagName("a");
                    foreach (HtmlElement elem in elems)
                    {
                        string tmp = elem.GetAttribute("href");
                        if (tmp.Contains("list="))
                        {
                            if (tmp.Contains("list=30"))
                            {
                                this.m_sGenre = "Star Wars";
                                break;
                            }
                            if (tmp.Contains("list=47"))
                            {
                                this.m_sGenre = "Harry Potter";
                                break;
                            }
                        }
                    }
                    break;
                case "harrypotterfanfiction.com":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "portkey.org":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "schnoogle.com":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "skyehawke.com":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "fictionalley.org":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "astronomytower.org":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "thedarkarts.org":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "riddikulus.org":
                    this.m_sGenre = "Harry Potter";
                    break;
                case "ficwad.com":
                    this.m_sGenre = "Harry Potter";
                    break;
            }
            
        }

        private void getTitle()
        {
            int start;
            int end;
            string docTitle;
            
            switch (_site)
            {
                case "fanfiction.net":
                    this.Title = filterFFNTitle(_wb.DocumentTitle);
                    break;
                case "fanficauthors.net":
                    start = this.m_sAddress.IndexOf("/");
                    end = this.m_sAddress.LastIndexOf("/");
                    this.Title = this.m_sAddress.Substring(start + 1, end - (start + 1));
                    break;
                case "adultfanfiction.net":
                    HtmlElementCollection elems = this.Story.GetElementsByTagName("option");
                    foreach (HtmlElement elem in elems)
                    {
                        if (elem.InnerText.Contains("1."))
                        {
                            string name = elem.InnerText.Substring(2).Trim();
                            this.Title = name;
                            break;
                        }
                    }
                    break;
                case "harrypotterfanfiction.com":
                    break;
                case "portkey.org":
                    docTitle = _wb.DocumentTitle;
                    if (docTitle.Contains("profile"))
                    {
                        this.m_sTitle = null;
                        return;
                    }
                    start = (docTitle.IndexOf(">>") + 2);
                    end = docTitle.LastIndexOf("-");
                    docTitle = docTitle.Substring(start, end - start);
                    docTitle = removeIllegalCharacters(docTitle);
                    this.Title = docTitle;
                    break;
                case "schnoogle.com":
                    start = _wb.DocumentTitle.IndexOf("(");
                    this.Title = _wb.DocumentTitle.Substring(0, start - 1);
                    break;
                case "skyehawke.com":
                    docTitle = _wb.DocumentTitle;
                    start = docTitle.LastIndexOf("::");
                    this.Title = docTitle.Substring(start+2).Trim();
                    break;
                case "fictionalley.org":
                    start = _wb.DocumentTitle.IndexOf("(");
                    this.Title = _wb.DocumentTitle.Substring(0, start - 1);
                    break;
                case "astronomytower.org":
                    start = _wb.DocumentTitle.IndexOf("(");
                    this.Title = _wb.DocumentTitle.Substring(0, start - 1);
                    break;
                case "thedarkarts.org":
                    start = _wb.DocumentTitle.IndexOf("(");
                    this.Title = _wb.DocumentTitle.Substring(0, start - 1);
                    break;
                case "riddikulus.org":
                    start = _wb.DocumentTitle.IndexOf("(");
                    this.Title = _wb.DocumentTitle.Substring(0, start - 1);
                    break;
                case "ficwad.com":
                    break;
            }
        }

        public string PathToSavedFile
        {
            get { return this._completepath; }
        }

        public void writeText()
        {
            this.writeTextFile();
        }

        public void writeHtml()
        {
            this.writeHtmlFile(ref _wb);
        }

    }
}
