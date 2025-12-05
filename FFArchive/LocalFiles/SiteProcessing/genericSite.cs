using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;


namespace FFArchive.LocalFiles.SiteProcessing
{
    public abstract class genericSite
    {
        protected HtmlDocument story;
        protected string _htmlText;
        protected string m_sGenre;
        protected string m_sSiteName;
        protected string m_sTitle;
        protected string m_sAuthor;
        protected string m_sFileName;
        protected string m_sSavePath;       //path to root save directory
        protected string m_sFilePath;       //path to final save directory
        protected string m_sAddress;
        protected string m_sDocumentText;
        protected string _completepath;

        protected abstract void parseSiteData();

        protected string PathToFile
        {
            get { return _completepath; }
        }
        
        protected HtmlDocument Story
        {
            get { return story; }
            set { story = value; }
        }

        protected string HtmlText
        {
            get { return _htmlText; }
            set { _htmlText = value; }
        }

        protected string PageAddress
        {
            get { return m_sAddress; }
            set 
            {
                if (value.StartsWith("http://"))
                {
                    m_sAddress = stripHttp(value);
                }
                else
                {
                    m_sAddress = value;
                }
            }
        }

        protected string FilePath
        {
            get { return m_sFilePath; }
            set { m_sFilePath = value; }
        }

        protected string DocumentText
        {
            get { return m_sDocumentText; }
        }

        protected string AuthorName
        {
            get { return m_sAuthor; }
        }

        protected string Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; }
        }

        protected string FileName
        {
            get { return m_sFileName; }
        }

        protected string Genre
        {
            get { return m_sGenre; }
        }

        protected string WebSite
        {
            get { return m_sSiteName; }
            set { m_sSiteName = value; }
        }

        protected string SavePath
        {
            get { return m_sSavePath; }
            set { m_sSavePath = value; }
        }

        protected string buildPath()
        {
            string tmp = "";
            try
            {
                tmp += m_sSavePath;
                tmp += Path.DirectorySeparatorChar;
                tmp += m_sSiteName;
                tmp += Path.DirectorySeparatorChar;
                tmp += m_sGenre;
                tmp += Path.DirectorySeparatorChar;
                tmp += m_sAuthor;
                tmp += Path.DirectorySeparatorChar;
                tmp += m_sTitle;
                tmp += Path.DirectorySeparatorChar;
                Directory.CreateDirectory(tmp);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + tmp, "Error Creating Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tmp = null;
            }

            return tmp;

        }

        protected string stripHttp(string address)
        {
            int p = address.IndexOf("http://");
            address = address.Substring(p + 7);
            return address;
        }

        protected string padFileName(string filename)
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
            else
            {
                return filename;
            }
        }

        protected StringCollection stripHtml()
        {
            HtmlElementCollection elems = story.GetElementsByTagName("p");
            StringCollection text = new StringCollection();
            bool test = false;

            foreach (HtmlElement elem in elems)
            {
                text.Add(elem.InnerText);
                test = true;
            }

            if (test)
            {
                return text;
            }
            else
            {
                return null;
            }
        }

        protected void writeTextFile()
        {
            string localPath = m_sFilePath + m_sFileName + ".txt";
            _completepath = localPath;

            StringCollection tmp = stripHtml();

            if (tmp != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(localPath, false, Encoding.Unicode);
                    foreach (string line in tmp)
                    {
                        sw.Write(line);
                        sw.Write(Environment.NewLine);
                        sw.Write(Environment.NewLine);
                    }
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("You do not have permission to create this file.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (ArgumentNullException) 
                {
                    MessageBox.Show("Path is a null string.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Invalid Characters in Path.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (PathTooLongException )
                {
                    int l = localPath.Length - 255;
                    MessageBox.Show("Path is too long by " + l + " characters.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DirectoryNotFoundException )
                {
                    MessageBox.Show("Path Not Found.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NotSupportedException )
                {
                    MessageBox.Show("Invalid Path Format", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        protected void writeHtmlFile(ref WebBrowser wb)
        {
            string localpath;

            if (Path.GetExtension(m_sFileName).Contains("htm"))
            {
                localpath = m_sFilePath + m_sFileName;
            }
            else
            {
                localpath = m_sFilePath + m_sFileName + ".html";
            }

            _completepath = localpath;

            try
            {
                StreamWriter sw = File.CreateText(localpath);
                sw.Write(wb.DocumentText);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to create this file.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Path is a null string.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid Characters in Path.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException)
            {
                int l = localpath.Length - 255;
                MessageBox.Show("Path is too long by " + l + " characters.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Path Not Found.", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Invalid Path Format", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
